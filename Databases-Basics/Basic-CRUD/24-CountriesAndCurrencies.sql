SELECT C.CountryName, C.CountryCode, 
CASE 
	WHEN C.CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
END AS "Currency" 
FROM [dbo].Countries AS C
ORDER BY C.CountryName ASC
