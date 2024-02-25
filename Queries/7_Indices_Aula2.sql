-- Antes da criação do índice
EXPLAIN ANALYZE SELECT "OrderID", "CustomerID", "TotalAmount"
FROM "Order"
WHERE "CustomerID" = 1;

-- Crie um índice na coluna "CustomerID" da tabela "Order"
CREATE INDEX idx_Order_CustomerID ON "Order" ("CustomerID");

-- Consulta de exemplo usando o índice
SELECT "OrderID", "CustomerID", "TotalAmount"
FROM "Order"
WHERE "CustomerID" = 1;

/*Lembre-se de que a criação de índices pode melhorar o desempenho das consultas, 
mas também pode afetar o desempenho das operações de atualização,
como inserção, atualização e exclusão.*/

-- Depois da criação do índice
EXPLAIN ANALYZE SELECT "OrderID", "CustomerID", "TotalAmount"
FROM "Order"
WHERE "CustomerID" = 1;






