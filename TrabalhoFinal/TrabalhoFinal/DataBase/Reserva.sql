DROP TABLE reservas;
CREATE TABLE reservas(
	id			INT IDENTITY(1,1),
	login		VARCHAR(50),
	senha		VARCHAR(12),
	nome		VARCHAR(100),
	celular		VARCHAR(15),
	cpf			VARCHAR(14),
	pagamento	VARCHAR(8)

);
INSERT INTO reservas(login, senha, nome, celular, cpf, pagamento) VALUES('igorjuanW@gmail.com', '123456789', 'Ygor Juan Wasen', '(47) 99138-1934', '106.255.419-64', 'dinhero');

SELECT * FROM reservas;