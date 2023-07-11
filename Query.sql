SELECT   
	c.[Name] AS CategoryName,   
	p.[Name] AS ProductName
FROM t_Products as p 
LEFT JOIN t_ProductCategory as pc ON pc.ProductId = p.Id 
LEFT JOIN t_Categories as c ON c.Id = pc.CategoryId
--FULL OUTER JOIN t_Categories as c ON c.Id = pc.CategoryId -- +Категории без продуктов
 ORDER BY CategoryName, ProductName