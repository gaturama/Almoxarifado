CREATE SCHEMA IF NOT EXISTS `almoxarifado` DEFAULT CHARACTER SET utf8 ;
USE `almoxarifado` ;

-- -----------------------------------------------------
-- Table `almoxarifado`.`Produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `almoxarifado`.`Produto` (
  `idProduto` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(250) NOT NULL,
  `preco` DOUBLE NOT NULL,
  PRIMARY KEY (`idProduto`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `almoxarifado`.`Almoxarifado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `almoxarifado`.`Almoxarifado` (
  `idAlmoxarifado` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`idAlmoxarifado`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `almoxarifado`.`Saldo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `almoxarifado`.`Saldo` (
  `idSaldo` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(250) NOT NULL,
  `idProduto` INT NOT NULL,
  `idAlmoxarifado` INT NOT NULL,
  PRIMARY KEY (`idSaldo`, `idProduto`, `idAlmoxarifado`),
  INDEX `fk_Saldo_Produto_idx` (`idProduto` ASC) ,
  INDEX `fk_Saldo_Almoxarifado1_idx` (`idAlmoxarifado` ASC) ,
  CONSTRAINT `fk_Saldo_Produto`
    FOREIGN KEY (`idProduto`)
    REFERENCES `almoxarifado`.`Produto` (`idProduto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Saldo_Almoxarifado1`
    FOREIGN KEY (`idAlmoxarifado`)
    REFERENCES `almoxarifado`.`Almoxarifado` (`idAlmoxarifado`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


ALTER TABLE saldo
ADD quantidade INT NOT NULL;

ALTER TABLE almoxarifado DROP COLUMN quantidade;
ALTER TABLE saldo DROP COLUMN nome;
 
ALTER TABLE produto RENAME TO produtos;
ALTER TABLE almoxarifado RENAME TO almoxarifados;
ALTER TABLE saldo RENAME TO saldos;