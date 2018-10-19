
1) Créer la base de données
	via la PMC exécuter les commandes suivantes : 
	- Add-Migration InitialCreate
	- Update-Database
	
2) Initialiser les données dans la base en exécutant le programme : TuiFlightConsoleApp.exe

3) Tests
	a) Pour trouver les bons vols, Vérifier la bonne période pour le bon vol dans la base, table Flight
	(Un exemple : From PARIS-ORLY to BRUXELLES on 22/10/2018 devrait vous renvoyer des résultats de vols à choisir pour effectuer un booking)
	b) Listing Voyages bookés/effectués : https://localhost:44376/travel

4) Notes
	La formule de calcul des distances a été implémentée et se trouve sous TuiFlight.Business.GetDistanceBetweenToPoints(params)
	Je n'aurai pas le temps de l'insérer dans les écrans

Commentaire :
		Il n'a pas été facile pour moi de trouver du temps pour faire ce travail dans de meilleurs delais. En effet vous n'êtes pas les seuls
		à exiger ce genre d'exercices et d'autres proposent des tests via coding-games et similaires. 
		Tout ceci, sans parler de mes responsabilités strictement personnelles entre autres
		
References : 
	Données Aéroports :  https://www.wego.fr/aeroports/
	Calcul de la distance : https://www.developpez.net/forums/d1366331/dotnet/langages/csharp/calcul-distance-entre-2-coordonnee-gps/
	Verification Calcul distance :	https://www.lexilogos.com/calcul_distances.htm
