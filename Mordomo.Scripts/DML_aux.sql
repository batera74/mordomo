INSERT INTO `AndressType` (`AndressType_Id`, `Name`, `CreationTime`, `LastUpdate`) 
VALUES 
(1, 'Residencial', NOW(), NOW()), 
(2, 'Comercial', NOW(), NOW());

INSERT INTO `CreditCardType` (`CreditCardType_Id`, `Name`, `CreationTime`, `LastUpdate`) 
VALUES 
(1, 'VISA', NOW(), NOW()), 
(2, 'MASTERCARD', NOW(), NOW()),
(3, 'AMERICAN EXPRESS', NOW(), NOW());

INSERT INTO `Status` (`Status_Id`, `Description`, `CreationTime`, `LastUpdate`) 
VALUES
(1, 'Aprovado', NOW(), NOW()),
(2, 'Aguardo Propostas', NOW(), NOW()),
(3, 'Propostas Realizadas', NOW(), NOW()),
(4, 'Proposta Escolhida', NOW(), NOW()),
(5, 'Recusado', NOW(), NOW()),
(6, 'Aguardando Pagamento', NOW(), NOW()),
(7, 'Pagamento Aprovado', NOW(), NOW()),
(8, 'Aguardando Realização do Serviço', NOW(), NOW()),
(9, 'Serviço Realizado', NOW(), NOW());

INSERT INTO `PaymentMethod` (`PaymentMethod_Id`, `Name`, `CreationTime`, `LastUpdate`)
VALUES
(1, 'Cartão de Crédito', NOW(), NOW()),
(2, 'Cartão de Débito', NOW(), NOW()),
(3, 'Boleto Bancário', NOW(), NOW());
