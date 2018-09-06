DROP TABLE clientes;
CREATE TABLE clientes(
	id					INT IDENTITY(1,1),
	nome_completo		VARCHAR(100) NOT NULL,
	email				VARCHAR(50) NOT NULL,
	senha				VARCHAR(12) NOT NULL,
	celular				VARCHAR(14) NOT NULL,
	data_nascimento		DATE NOT NULL,
	cpf					VARCHAR(14) NOT NULL,
	estado				VARCHAR(50) NOT NULL,
	cidade				VARCHAR(100) NOT NULL,
	bairro				VARCHAR(50) NOT NULL,
	logradouro			VARCHAR(250) NOT NULL,
	cep					VARCHAR(9) NOT NULL
);

INSERT INTO clientes (nome_completo, login, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep) VALUES ('Austin Gillispie', 'austin12', 'austin12', '47 9563-5412', '1951-06-21', '505.310.755-67', 'Rio de Janeiro', 'Rio de Janeiro', 'Botafogo', 'Rua São Clemente', '22260-006');