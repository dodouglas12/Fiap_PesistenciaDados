--Calcula o valor total de compras feitas por um cliente específico. 
--A função receberá o ID do cliente como parâmetro e retornará o valor total das compras desse cliente.

CREATE OR REPLACE FUNCTION calcular_valor_total_compras(cliente_id INT)
RETURNS NUMERIC AS $$
DECLARE
    total_compras NUMERIC := 0;
BEGIN
    SELECT SUM("Order"."TotalAmount")
    INTO total_compras
    FROM "Customer"
    JOIN "Order" ON "Customer"."CustomerID" = "Order"."CustomerID"
    WHERE "Customer"."CustomerID" = cliente_id;

    RETURN total_compras;
END;
$$ LANGUAGE plpgsql;

--query
SELECT calcular_valor_total_compras(1);

