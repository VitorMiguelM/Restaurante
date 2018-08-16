CREATE TABLE clientes(
	id					INT IDENTITY(1,1),
	nome_completo		VARCHAR(100) NOT NULL,
	login				VARCHAR(12) NOT NULL,
	senha				VARCHAR(12) NOT NULL,
	celular				VARCHAR(14) NOT NULL,
	data_nascimento		DATE NOT NULL,
	cpf					VARCHAR(14) NOT NULL,
	estado				VARCHAR(50) NOT NULL,
	cidade				VARCHAR(100) NOT NULL,
	bairo				VARCHAR(50) NOT NULL,
	logradouro			VARCHAR(250) NOT NULL,
	cep					VARCHAR(9) NOT NULL
);