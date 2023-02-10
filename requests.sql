--Since both products and categories can contain multiple references of each other 
--a seperate table containing every product.id and category.id pair has to exist.

SELECT P.Name, C.Name
FROM Product P LEFT JOIN ProductCategoryPair PCP ON 
P.ID = PCP.ProdID
LEFT JOIN Category C ON
PCP.CatID = C.ID
