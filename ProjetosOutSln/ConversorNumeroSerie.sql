--Criando tabela de numeros de série
CREATE TABLE NUMEROS_DE_SERIE(
NUMERO NVARCHAR(30),
CODIGO_INTERACAO INT
);

INSERT INTO NUMEROS_DE_SERIE(NUMERO, CODIGO_INTERACAO)
SELECT NUMERODESERIE, CODIGO
FROM INTERACOES
WHERE NUMERODESERIE != '';

ALTER TABLE INTERACOES
DROP COLUMN NUMERODESERIE;

-- Remoçao do campo descrição
UPDATE PRODUTOS
SET DESCRICAO = IIF(DESCRICAO = OBSERVACAO, DESCRICAO, DESCRICAO + ' ' + OBSERVACAO);

ALTER TABLE PRODUTOS
DROP COLUMN OBSERVACAO;

SP_RENAME 'DESCRICAO', 'OBSERVACAO', 'COLUMN'

