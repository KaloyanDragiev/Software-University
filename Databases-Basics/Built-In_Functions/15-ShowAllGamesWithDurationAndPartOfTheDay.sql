SELECT G.Name AS "Game", 
CASE 
	WHEN DATEPART(hh, G.Start) >= 0 AND DATEPART(hh, G.Start) < 12 THEN 'Morning'
	WHEN DATEPART(hh, G.Start) >= 12 AND DATEPART(hh, G.Start) < 18 THEN 'Afternoon'
	WHEN DATEPART(hh, G.Start) >= 18 AND DATEPART(hh, G.Start) < 24 THEN 'Evening'
END AS "Part of the Day",
CASE
	WHEN G.Duration <= 3 THEN 'Extra Short'
	WHEN G.Duration >= 4 AND G.Duration <= 6 THEN 'Short'
	WHEN G.Duration > 6 THEN 'Long'
	WHEN G.Duration IS NULL THEN 'Extra Long'
END AS "Duration"
FROM [dbo].Games AS G
ORDER BY G.Name ASC, [Duration] ASC, [Part of the Day] ASC
