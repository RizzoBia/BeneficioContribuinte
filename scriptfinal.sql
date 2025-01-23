-- criação das tabelas
CREATE TABLE "Beneficios" (
    "Id" SERIAL PRIMARY KEY,
    "Nome" VARCHAR(100) NOT NULL,
    "PercentualDesconto" NUMERIC(5, 2) NOT NULL, -- DECIMAL em PostgreSQL é sinônimo de NUMERIC
    "QuantidadeContribuintes" INTEGER DEFAULT 0
);



CREATE TABLE "Contribuintes" (
    "Id" SERIAL PRIMARY KEY,
    "CNPJ" VARCHAR(20) NOT NULL,
    "RazaoSocial" VARCHAR(200) NOT NULL,
    "DataAbertura" DATE NOT NULL,
    "RegimeTributacao" VARCHAR(50) NOT NULL,
    "PossuiBeneficio" BOOLEAN NOT NULL DEFAULT FALSE,
    "BeneficioId" INT REFERENCES "Beneficios"("Id")
);

-- inserindo dados fictícios

INSERT INTO public."Beneficios" (
    "Nome", "PercentualDesconto"
) VALUES
('Desconto de 10%', 10.00),
('Desconto de 15%', 15.00),
('Desconto de 20%', 20.00),
('Desconto para MEEPP', 17.00),
('Desconto para MEI', 12.50);

INSERT INTO public."Contribuintes" (
    "CNPJ", "RazaoSocial", "DataAbertura", "RegimeTributacao", "PossuiBeneficio", "BeneficioId"
) VALUES
-- Empresa com benefício vinculado
('12345678000190', 'Empresa Alpha Ltda', '2020-05-15', 'Variavel', true, 1),
('98765432000167', 'Beta Comércio S.A.', '2018-11-23', 'MEI', true, 2),
('19283746000102', 'Gamma Serviços ME', '2021-01-10', 'MEEPP', true, 3),
-- Empresa sem benefício vinculado
('56473829000189', 'Delta Industrial EPP', '2019-07-30', 'Variavel', false, NULL),
('10293847560013', 'Epsilon Tech Ltda', '2022-03-05', 'MEI', false, NULL),
-- Outras empresas com benefício vinculado
('11223344550011', 'Zeta Transporte Ltda', '2020-06-15', 'MEEPP', true, 4),
('22334455660022', 'Omega Consultoria MEI', '2021-09-10', 'MEI', true, 5),
-- Empresa com benefício mas sem vinculação explícita
('33445566770033', 'Sigma Construções EPP', '2022-01-20', 'Variavel', false, NULL),
-- Testes adicionais
('44556677880044', 'Kappa Serviços Técnicos Ltda', '2017-03-25', 'MEEPP', true, 1),
('55667788990055', 'Theta Digital S.A.', '2019-05-15', 'Variavel', false, NULL);
