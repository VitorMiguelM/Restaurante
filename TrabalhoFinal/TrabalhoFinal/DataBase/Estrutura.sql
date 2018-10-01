DROP TABLE funcionarios;
DROP TABLE ingredientes_pratos;
DROP TABLE pratos;
DROP TABLE ingredientes;
DROP TABLE reservas;
DROP TABLE clientes;

CREATE TABLE clientes(
	id					INT IDENTITY(1,1),
	nome_completo		VARCHAR(100) NOT NULL,
	[email]				VARCHAR(50) NOT NULL,
	login				VARCHAR(50) NOT NULL,
	senha				VARCHAR(12) NOT NULL,
	celular				VARCHAR(16) NOT NULL,
	data_nascimento		DATE NOT NULL,
	cpf					VARCHAR(14) NOT NULL,
	estado				VARCHAR(50) NOT NULL,
	cidade				VARCHAR(100) NOT NULL,
	bairro				VARCHAR(50) NOT NULL,
	logradouro			VARCHAR(250) NOT NULL,
	cep					VARCHAR(9) NOT NULL
);

CREATE TABLE reservas(
	id			INT IDENTITY(1,1),
	login		VARCHAR(50),
	senha		VARCHAR(12),
	nome		VARCHAR(100),
	celular		VARCHAR(15),
	cpf			VARCHAR(14),
	pagamento	VARCHAR(8)

);

CREATE TABLE pratos(
	id							INT IDENTITY(1,1) PRIMARY KEY,
	nome						VARCHAR(200) NOT NULL,
	modo_preparo				VARCHAR(2000) NOT NULL,
	propriedades_nutricionais	VARCHAR(500)NOT NULL,
	email						VARCHAR(100),
	celular                     VARCHAR(12) ,
	preco					    DECIMAL(12,2),
	descricao					TEXT ,
);

CREATE TABLE ingredientes(
	id		INT IDENTITY(1,1) PRIMARY KEY,
	nome	VARCHAR(200)
);

CREATE TABLE ingredientes_pratos(
	id				INT IDENTITY(1,1),
	id_prato		INT,
	id_ingrediente	INT,
	FOREIGN KEY (id_prato) REFERENCES pratos(id),
	FOREIGN KEY (id_ingrediente) REFERENCES ingredientes(id)
);

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


INSERT INTO reservas(login, senha, nome, celular, cpf, pagamento) VALUES('hmdcampos@gmail.com','991310455','Henrique Mateus Dalfovo Campos','(47) 99131-0455','052.186.589-10','Dinheiro');

INSERT INTO funcionarios(nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep, cargo) VALUES('Ygor juan', 'Wasen', '91381934', '98659865', '2000/02/02', '106.265.419-64', 'Santa Catarina', 'Blumenau', 'tribess', 'loja magazineluiza', '95684-888', 'gerente');
SELECT *  FROM reservas;

SELECT nome_completo, email, login, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep FROM clientes WHERE id = 1;

SELECT * FROM clientes;