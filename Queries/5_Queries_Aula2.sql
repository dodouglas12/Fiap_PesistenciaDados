--Encontrando o produto mais caro:
SELECT "Name", "Price"
FROM "Product"
ORDER BY "Price" DESC
LIMIT 1;

--Encontrando pedidos com um valor total superior a um determinado limite:
SELECT "Order"."OrderID", "Order"."TotalAmount"
FROM "Order"
WHERE "Order"."TotalAmount" > 50.00;

--Encontrar os clientes que gastaram mais de $100 em pedidos:
SELECT "Customer"."Name", SUM("Order"."TotalAmount") AS "TotalSpent"
FROM "Customer"
LEFT JOIN "Order" ON "Customer"."CustomerID" = "Order"."CustomerID"
GROUP BY "Customer"."Name"
HAVING SUM("Order"."TotalAmount") > 100;

--Encontrar os produtos que foram pedidos mais de 1 vezes:
SELECT "Product"."Name", COUNT("OrderLine"."OrderLineID") AS "OrderCount"
FROM "Product"
INNER JOIN "OrderLine" ON "Product"."ProductID" = "OrderLine"."ProductID"
GROUP BY "Product"."Name"
HAVING COUNT("OrderLine"."OrderLineID") > 1;

--Encontrar o cliente que gastou mais em um único pedido:
SELECT "Customer"."Name", MAX("Order"."TotalAmount") AS "MaxSpent"
FROM "Customer"
LEFT JOIN "Order" ON "Customer"."CustomerID" = "Order"."CustomerID"
GROUP BY "Customer"."Name"
ORDER BY "MaxSpent" DESC
LIMIT 1;


--Encontrar todos os pedidos feitos após o primeiro pedido de um cliente:

ALTER TABLE "Order"
ADD COLUMN "OrderDate" DATE;

UPDATE "Order"
SET "OrderDate" = '2023-08-15'
WHERE "OrderID" = 1;

UPDATE "Order"
SET "OrderDate" = '2023-08-20'
WHERE "OrderID" = 2;

UPDATE "Order"
SET "OrderDate" = '2023-08-25'
WHERE "OrderID" = 3;


SELECT "Order"."OrderID", "Order"."OrderDate"
FROM "Order"
WHERE "Order"."OrderDate" >
  (SELECT MIN("OrderDate")
   FROM "Order"
   WHERE "CustomerID" = 1);

--Calcular o valor médio gasto por cliente em pedidos:
SELECT "Customer"."Name", AVG("Order"."TotalAmount") AS "AverageSpent"
FROM "Customer"
LEFT JOIN "Order" ON "Customer"."CustomerID" = "Order"."CustomerID"
GROUP BY "Customer"."Name";


-- Listar IDs e nomes de clientes e produtos em uma única lista ordenada por ID
SELECT "CustomerID" AS "ID", "Name" AS "Nome"
FROM "Customer"
UNION ALL
SELECT "ProductID", "Name"
FROM "Product"
ORDER BY "ID";

--Buscar todos produtos que tenham A no começo ou no final
SELECT "ProductID", "Name", "Price"
FROM "Product"
WHERE "Name" LIKE '%A%';

