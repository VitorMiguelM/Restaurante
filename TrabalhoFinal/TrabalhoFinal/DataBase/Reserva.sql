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
INSERT INTO reservas(login, senha, nome, celular, cpf, pagamento) VALUES('hmdcampos@gmail.com', '991310455', 'Henrique Mateus Dalfovo Campos', '(47) 99131-0455', '052.186.589-10', 'dinhero');

SELECT * FROM reservas;