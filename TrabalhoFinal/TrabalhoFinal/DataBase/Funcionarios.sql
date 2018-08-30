CREATE TABLE funcionarios(
	id					INT IDENTITY(01,1),
	nome				VARCHAR(20) NOT NULL,
	sobrenome			VARCHAR(20) NOT NULL,
	senha				VARCHAR(50) NOT NULL,
	celular				VARCHAR(14) NOT NULL,
	data_nascimento		DATE NOT NULL,
	cpf					VARCHAR(14) NOT NULL,
	estado				VARCHAR(50) NOT NULL,
	cidade				VARCHAR(100) NOT NULL,
	bairro				VARCHAR(50) NOT NULL,
	logradouro			VARCHAR(100) NOT NULL,
	cep					VARCHAR(9) NOT NULL,
	cargo				VARCHAR(20) NOT NULL
);
INSERT INTO funcionarios VALUES('jefersson','da costta', 123456789, '91364852', '2000/05/05', '515.854.546-99','Santa catarina', 'blumaenau', 'tribess','rua hermann tribes', '98468-999','faxineiro');
SELECT * FROM funcionarios;