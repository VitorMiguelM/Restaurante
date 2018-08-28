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

INSERT INTO funcionarios (nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep, cargo) VALUES('Jefersson','da Silva', 123456789, '(47) 9136-4852', '2000-05-05', '515.854.546-99','Santa catarina', 'Blumenau', 'Tribess','Rua Hermann Tribess', '85468-999','Faxineiro');