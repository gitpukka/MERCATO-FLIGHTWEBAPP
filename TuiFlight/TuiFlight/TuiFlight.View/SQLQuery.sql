select t.*
FROM [dbo].[Travels] t
INNER JOIN [dbo].[Customers] c on t.CustomerId = c.CustomerId
WHERE c.FirstName = 'TOTO'