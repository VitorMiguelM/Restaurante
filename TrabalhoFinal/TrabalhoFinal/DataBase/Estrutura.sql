﻿DROP TABLE funcionarios;
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

CREATE TABLE reservas(
	id			INT IDENTITY(1,1),
	login		VARCHAR(50),
	senha		VARCHAR(12),
	nome		VARCHAR(100),
	celular		VARCHAR(15),
	cpf			VARCHAR(14),
	pagamento	VARCHAR(8)

);

INSERT INTO clientes(nome_completo, email, login, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep) VALUES('Carlos Grew de souza', 'CarlosGrew@gmail.com', 'CarlosG', '123', '4796065334', '20000202', '10626541964', 'Santa Catarina', 'Blumenau', 'Tribess', 'Rua São Francisco', '95684888');

INSERT INTO funcionarios(nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep, cargo) VALUES('Carlos', 'Grew', '91381934', '98659865', '20000202', '10626541964', 'Santa Catarina', 'Blumenau', 'Tribess', 'Rua São Francisco', '95684888', 'Caixa'); 

INSERT INTO reservas(login, senha, nome, celular, cpf, pagamento) VALUES('Reserva@gmail.com','991310455','','(47) 99131-0455','052.186.589-10','Dinheiro');

SELECT * FROM clientes;
SELECT * FROM funcionarios;
SELECT * From reservas;
