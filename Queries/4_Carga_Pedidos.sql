-- Inserindo dados na tabela "Customer"
INSERT INTO "Customer" ("Name", "Address1", "Address2", "Address3")
VALUES
    ('Customer 1', 'Address 1.1', 'Address 1.2', 'Address 1.3'),
    ('Customer 2', 'Address 2.1', 'Address 2.2', 'Address 2.3');

-- Inserindo dados na tabela "OrderStatus"
INSERT INTO "OrderStatus" ("Name")
VALUES
    ('Pending'),
    ('Processing'),
    ('Completed');

-- Inserindo dados na tabela "Product"
INSERT INTO "Product" ("Name", "Price")
VALUES
    ('Product A', 19.99),
    ('Product B', 29.99),
    ('Product C', 9.99);

-- Inserindo dados na tabela "Order"
INSERT INTO "Order" ("CustomerID", "TotalAmount", "OrderStatusID")
VALUES
    (1, 49.95, 1),
    (1, 89.97, 2),
    (2, 19.99, 1);

-- Inserindo dados na tabela "OrderLine"
INSERT INTO "OrderLine" ("OrderID", "ProductID", "Quantity")
VALUES
    (1, 1, 2),
    (1, 2, 3),
    (2, 1, 1),
    (2, 2, 2),
    (3, 3, 1);