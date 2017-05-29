---CONSULTAS DE SELECCIÓN
SELECT * FROM Services

SELECT name, id FROM Services

SELECT name, id 
FROM Services
ORDER BY name, id DESC, hiddenId

SELECT *
FROM Services
WHERE deleted = 0

SELECT *
FROM Services
WHERE deleted = 0 AND status = 0

SELECT *
FROM Services
WHERE deleted = 0 AND price <> 20

SELECT *
FROM Services
WHERE idUserResponse IS NOT NULL

SELECT *
FROM Services
--WHERE name LIKE 'Visita%'
--WHERE name LIKE '%Visita'
WHERE name LIKE '%Visita%'

SELECT *
FROM Services
WHERE tags LIKE 'c%ches'

SELECT count (*) as 'Total de filas' 
FROM Services

SELECT max(price) as PrecioAlto
FROM Services

SELECT min(price) as PrecioBajo
FROM Services

SELECT sum(price) as TotalPrecio
FROM Services

SELECT avg(price) as PrecioMedio
FROM Services

SELECT distinct deleted FROM Services


SELECT count(*), deleted 
FROM Services
GROUP BY deleted 

SELECT count(*), deleted , isAdmin 
FROM Users
GROUP BY deleted, isAdmin, email

SELECT * FROM Users

SELECT count(*) as 'Nº Filas', deleted , isAdmin, email 
FROM Users
WHERE hiddenId > 168 AND firstName LIKE '%e%'
GROUP BY deleted, isAdmin, email
ORDER BY email DESC


--CONSULTAS SOBRE VARIAS TABLAS

SELECT 
	S.id, S.name, S.description, COUNT(*)	
FROM Services S
	INNER JOIN ServiceImages  SI
	 on S.id = SI.idService
	 GROUP BY 
		S.id, S.name, S.description

SELECT 
	S.id, S.name, S.description, COUNT(*)	
FROM Services S
	INNER JOIN ServiceImages  SI
	 on S.id = SI.idService
	 GROUP BY 
		S.id, S.name, S.description


SELECT 
	S.id, S.name, S.description, SI.imageUrl	 
FROM Services S
	LEFT JOIN ServiceImages SI
	 on S.id = SI.idService
	 GROUP BY 
		S.id, S.name, S.description, SI.imageUrl
HAVING SI.imageUrl LIKE '%2.png'
	