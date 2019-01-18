CREATE SEQUENCE IDEXAMPLE;
COMMIT;

CREATE TABLE EXAMPLE(
  ID      NUMBER(6) NOT NULL,
  NAME    VARCHAR2(20 CHAR) NOT NULL,
  ACTIVE  NUMBER(1,0) NOT NULL 
);

ALTER TABLE EXAMPLE
  ADD CONSTRAINT PK_EXAMPLE
  PRIMARY KEY (ID);
  
CREATE OR REPLACE TRIGGER TG_PK_EXAMPLE before insert
on EXAMPLE for each row
begin
  SELECT IDEXAMPLE.NEXTVAL
    INTO :new.ID
    FROM DUAL;
end;  
/

COMMIT;