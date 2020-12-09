CREATE TABLE TB_CLIENTE(
  id              INT          NOT NULL AUTO_INCREMENT,
  nome            VARCHAR(20)  NOT NULL,
  RG              VARCHAR(20)  NOT NULL,
  CPF             VARCHAR(20)  NOT NULL,
  data_nascimento DATE         NOT NULL,
  telefone        VARCHAR(20)  NOT NULL,
  email           VARCHAR(150) NOT NULL,
  cod_empresa     INT          NOT NULL,
  
  PRIMARY KEY(id),
  CHECK (cod_empresa IN (1,2))
);

CREATE TABLE TB_CIDADE(
  id     INT NOT NULL AUTO_INCREMENT,
  nome   VARCHAR(100) NOT NULL,
  estado CHAR(2) NOT NULL,
  PRIMARY KEY(id)
);

CREATE TABLE TB_ENDERECO(
  id              INT          NOT NULL AUTO_INCREMENT,
  rua             VARCHAR(255) NOT NULL,
  bairro          VARCHAR(50)  NOT NULL,
  numero          VARCHAR(50)  NOT NULL,
  complemento     VARCHAR(100) NOT NULL,
  CEP             VARCHAR(10)  NOT NULL,
  tipo_endereco   INT          NOT NULL,
  tb_cidade_id    INT          NOT NULL,
  
  PRIMARY KEY(id),
  CHECK (tipo_endereco IN (1,2,3)),
  CONSTRAINT tb_endereco_fk1 FOREIGN KEY(tb_cidade_id) REFERENCES tb_cidade(id) ON DELETE CASCADE
);

CREATE TABLE TB_CLIENTE_ENDERECO(
  id              INT          NOT NULL AUTO_INCREMENT,
  tb_cliente_id   INT          NOT NULL,
  tb_endereco_id  INT          NOT NULL,
  
  PRIMARY KEY(id),
  CONSTRAINT tb_cliente_endereco_fk1 FOREIGN KEY(tb_cliente_id) REFERENCES tb_cliente(id)  ON DELETE CASCADE,
  CONSTRAINT tb_cliente_endereco_fk2 FOREIGN KEY(tb_endereco_id) REFERENCES tb_endereco(id)  ON DELETE CASCADE
);
