CREATE TABLE "Customer" (
    "CustomerID" serial PRIMARY KEY,
    "Name" varchar(100) NOT NULL,
    "Address1" varchar(200) NOT NULL,
    "Address2" varchar(200),
    "Address3" varchar(200)
);

CREATE TABLE "Order" (
    "OrderID" serial PRIMARY KEY,
    "CustomerID" int NOT NULL,
    "TotalAmount" numeric(10, 2) NOT NULL,
    "OrderStatusID" int NOT NULL
);

CREATE TABLE "OrderLine" (
    "OrderLineID" serial PRIMARY KEY,
    "OrderID" int NOT NULL,
    "ProductID" int NOT NULL,
    "Quantity" int NOT NULL
);

CREATE TABLE "Product" (
    "ProductID" serial PRIMARY KEY,
    "Name" varchar(200) NOT NULL,
    "Price" numeric(10, 2) NOT NULL
);

CREATE TABLE "OrderStatus" (
    "OrderStatusID" serial PRIMARY KEY,
    "Name" varchar(100) NOT NULL
);

ALTER TABLE "Order" ADD CONSTRAINT "fk_Order_CustomerID" FOREIGN KEY ("CustomerID")
REFERENCES "Customer" ("CustomerID");

ALTER TABLE "Order" ADD CONSTRAINT "fk_Order_OrderStatusID" FOREIGN KEY ("OrderStatusID")
REFERENCES "OrderStatus" ("OrderStatusID");

ALTER TABLE "OrderLine" ADD CONSTRAINT "fk_OrderLine_OrderID" FOREIGN KEY ("OrderID")
REFERENCES "Order" ("OrderID");

ALTER TABLE "OrderLine" ADD CONSTRAINT "fk_OrderLine_ProductID" FOREIGN KEY ("ProductID")
REFERENCES "Product" ("ProductID");

CREATE INDEX "idx_Customer_Name" ON "Customer" ("Name");
