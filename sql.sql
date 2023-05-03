-- Исходя из задания мы имеем связь "многие ко многим", значит имеется таблица ProductCategory. 

SELECT
	p.Name,
	c.Name
FROM Products AS p
LEFT JOIN ProductsCategories AS pc ON p.Id = pc.ProductId
JOIN Categories AS c ON pc.CategoryId = c.CategoryId