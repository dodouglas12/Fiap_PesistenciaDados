--Insere um novo pedido para um cliente específico.
--O procedimento receberá o ID do cliente e os detalhes do pedido (produto e quantidade) 
-- Crie um procedimento para inserir um novo pedido para um cliente
-- Crie um procedimento para inserir um novo pedido para um cliente com cálculo do TotalAmount
CREATE OR REPLACE PROCEDURE inserir_pedido(
    cliente_id INT,
    produto_id INT,
    quantidade INT
)
LANGUAGE plpgsql
AS $$
DECLARE
    valor_unitario NUMERIC;
    total_pedido NUMERIC;
BEGIN
    -- Obter o valor unitário do produto
    SELECT "Price" INTO valor_unitario
    FROM "Product"
    WHERE "ProductID" = produto_id;

    -- Calcular o valor total do pedido
    total_pedido := valor_unitario * quantidade;

    -- Inserir o novo pedido
    INSERT INTO "Order" ("CustomerID", "TotalAmount", "OrderStatusID", "OrderDate")
    VALUES (cliente_id, total_pedido, 1, CURRENT_DATE)
    RETURNING "OrderID" INTO cliente_id;

    -- Inserir a linha de pedido correspondente
    INSERT INTO "OrderLine" ("OrderID", "ProductID", "Quantity")
    VALUES (cliente_id, produto_id, quantidade);
END;
$$;

--Validando
CALL inserir_pedido(1, 2, 5);

SELECT calcular_valor_total_compras(1);
