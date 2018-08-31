CREATE TABLE reservas(
	id			INT IDENTITY(1,1),
	nome		VARCHAR(100),
	celular		VARCHAR(15),
	cpf			VARCHAR(14),
	horario		TIME,
	pagamento	TINYINT

);