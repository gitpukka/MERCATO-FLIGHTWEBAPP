using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuiFlight.View.ViewModel;
using TuiFlightDataContext;
using TuiFlightModel.Models;

namespace TuiFlight.View.Controllers
{
    public class TravelController : Controller
    {
        private readonly TuiFlightDbContext _context;

        public TravelController(TuiFlightDbContext context)
        {
            _context = context;
        }

        // GET: Travel
        public async Task<IActionResult> Index()
        {
            var travels = new List<BookingViewModel>();
            var tuiFlightDbContext = _context.Travels.Include(t => t.Traveller);
            var items = await tuiFlightDbContext.ToListAsync();

            foreach (var item in items)
            {
                var flight = _context.Flights
                    .Include(t => t.DepartureAirport)
                    .Include(t => t.DestinationAirport)
                    .FirstOrDefault(f => f.FlightId == item.OutboundFlightId);

                travels.Add(new BookingViewModel
                {
                    FlightId = flight.FlightId,
                    FlightName = flight.Name,
                    OutboundDate = flight.OutboundDate,
                    AirportFrom = flight.DepartureAirport.Name,
                    AirportTo = flight.DestinationAirport.Name,
                    TravellerFirstName = item.Traveller.FirstName,
                    TravellerLastName = item.Traveller.LastName
                });
            }
            return View(travels);
        }

        // GET: Travel/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travel = await _context.Travels
                .Include(t => t.Traveller)
                .FirstOrDefaultAsync(m => m.OutboundFlightId == id);
            if (travel == null)
            {
                return NotFound();
            }

            return View(travel);
        }

        // GET: Travel/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Travel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OutboundFlightId,CustomerId,OutboundDate,OneWay,ReturnFlightId,ReturnDate")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                travel.OutboundFlightId = Guid.NewGuid();
                _context.Add(travel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", travel.CustomerId);
            return View(travel);
        }

        // GET: Travel/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travel = await _context.Travels.FindAsync(id);
            if (travel == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", travel.CustomerId);
            return View(travel);
        }

        // POST: Travel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OutboundFlightId,CustomerId,OutboundDate,OneWay,ReturnFlightId,ReturnDate")] Travel travel)
        {
            if (id != travel.OutboundFlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelExists(travel.OutboundFlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", travel.CustomerId);
            return View(travel);
        }

        // GET: Travel/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travel = await _context.Travels
                .Include(t => t.Traveller)
                .FirstOrDefaultAsync(m => m.OutboundFlightId == id);
            if (travel == null)
            {
                return NotFound();
            }

            return View(travel);
        }

        // POST: Travel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var travel = await _context.Travels.FindAsync(id);
            _context.Travels.Remove(travel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelExists(Guid id)
        {
            return _context.Travels.Any(e => e.OutboundFlightId == id);
        }
    }
}
