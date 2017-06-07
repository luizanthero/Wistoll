create database wistoll;

use wistoll;

create table aud_auditoria(
	aud_cod int primary key auto_increment,
    aud_funcionario int,
    aud_tabela varchar(50) not null,
    aud_campoNome varchar(100) not null,
    aud_acao enum('Atualização', 'Exclusão', 'Inserção', 'Ativação', 'Alteração de Senha') not null,
    aud_data datetime not null,
    aud_dadosAntes text not null,
    aud_dadosDepois text not null
);

create table Mrq_ModeloRequerimento(
	mrq_cod int auto_increment,
    mrq_descricao varchar(45) not null,
    cod_fun int,
    constraint pk_mrq_cod primary key (mrq_cod)
);

create table Car_Cargo(
	car_cod int auto_increment,
    car_descricao varchar(50) not null,
    cod_fun int,
    constraint pk_car_cod primary key (car_cod)
);

create table Dep_Departamento(
	dep_cod int auto_increment,
    dep_nome varchar(45) not null,
    dep_descricao varchar(200),
    dep_ativo enum('Ativo', 'Inativo') not null default 'Ativo',
    cod_fun int,
    constraint pk_dep_cod primary key (dep_cod)
);

create table Set_Setor(
	set_cod int auto_increment,
    set_nome varchar(45) not null,
    set_descricao varchar(200) null,
    set_ativo enum('Ativo', 'Inativo') not null default 'Ativo',
    dep_cod int not null,
    cod_fun int,
    constraint pk_set_cod primary key (set_cod),
    constraint fk_set_dep_cod foreign key (dep_cod) references Dep_Departamento (dep_cod)
);

create table Pes_Pessoa(
	pes_cod int auto_increment,
	pes_nome varchar(50) not null,
    pes_sobrenome varchar(100),
	pes_dataNascimento varchar(20) not null,
    pes_rua varchar(45) not null,
	pes_numero varchar(45) not null,
	pes_complemento varchar(45),
	pes_bairro varchar(45) not null,
	pes_cep varchar(45) not null,
	pes_cidade varchar(45) not null,
	pes_estado varchar(45) not null,
    pes_rg varchar(45),
    pes_cpf varchar(45),
    pes_sexo varchar(45),
    pes_cnpj varchar (45),
    pes_sigla varchar(10),
    pes_razaoSocial varchar(100),
    pes_tipo enum('Fisica','Juridica') not null default 'Fisica',
    pes_ativo enum('Ativo', 'Inativo') not null default 'Ativo',
    cod_fun int,
	constraint pk_pes_cod primary key (pes_cod)
);

create table Pfl_Perfil(
	pfl_cod int auto_increment,
    pfl_descricao varchar(45) not null,
    pfl_imagem varchar(50),
    cod_fun int,
    constraint pk_pfl_cod primary key (pfl_cod)
);

create table Fun_Funcionario(
	fun_cod int auto_increment,
	fun_matricula varchar(45) not null,
    fun_senha varchar(300) not null,
    fun_chefeSetor tinyint(1) not null,
    fun_chefeDepartamento tinyint(1) not null,
    fun_primeiroAcesso tinyint(1) not null default 1,
    set_cod int not null,
    car_cod int not null,
    pes_cod int not null,
    pfl_cod int not null,
    cod_fun int,
	constraint pk_fun_cod primary key (fun_cod),
    constraint fk_fun_set_setor foreign key (set_cod) references Set_Setor (set_cod),
    constraint fk_fun_car_cargo foreign key (car_cod) references Car_Cargo (car_cod),
    constraint fk_fun_pes_cod foreign key (pes_cod) references Pes_Pessoa (pes_cod),
    constraint fk_fun_pfl_cod foreign key (pfl_cod) references Pfl_Perfil (pfl_cod)
);

create table Req_Requerente(
	req_cod int auto_increment,
    pes_cod int not null,
    cod_fun int,
    constraint pk_req_cod primary key (req_cod),
    constraint fk_req_pes_cod foreign key (pes_cod) references Pes_Pessoa (pes_cod)
);

create table Sta_Status(
	sta_cod int auto_increment,
    sta_valor varchar(50) not null,
    cod_fun int,
    constraint pk_sta_cod primary key (sta_cod)
);

create table Pro_Processo(
	pro_cod int auto_increment,
    pro_numeroProcesso varchar(50) not null,
    pro_dataPedido varchar(20) not null,
    pro_ativo varchar(20) not null default 'Ativo',
    mrq_cod int not null,
    req_cod int not null,
    sta_cod int not null,
    cod_fun int,
    constraint pk_pro_cod primary key (pro_cod),
    constraint fk_pro_mrq_cod foreign key (mrq_cod) references Mrq_ModeloRequerimento (mrq_cod),
    constraint fk_pro_req_cod foreign key (req_cod) references Req_Requerente (req_cod),
    constraint fk_pro_sta_cod foreign key (sta_cod) references Sta_Status (sta_cod)
);

create table Dpr_DetalheProcesso(
	dpr_cod int auto_increment,
    dpr_dataFinalizar varchar(20),
    pro_cod int not null,
    cod_fun int,
    constraint pk_dpr_cod primary key (dpr_cod),
    constraint fk_dpr_pro_cod foreign key (pro_cod) references Pro_Processo (pro_cod)
);

create table Anx_Anexos(
	anx_cod int auto_increment,
    anx_nome varchar(45) not null,
    anx_descricao varchar(45) not null,
    dpr_cod int not null,
    cod_fun int,
    constraint pk_anx_cod primary key (anx_cod),
    constraint fk_anx_dpr_cod foreign key (dpr_cod) references Dpr_DetalheProcesso (dpr_cod)
);

create table Pro_Fun(
	fun_cod int not null,
    pro_cod int not null,
    cod_fun int,
    constraint pk_pro_fun_cod primary key (fun_cod, pro_cod),
    constraint fk_pro_fun_fun_cod foreign key (fun_cod) references Fun_Funcionario (fun_cod),
    constraint fk_pro_fun_pro_cod foreign key (pro_cod) references Pro_Processo (pro_cod)
);

create table Tra_Tramitacao(
	tra_cod int auto_increment,
    tra_localAtual varchar(50) not null,
    tra_localAnterior varchar(50),
    tra_localEnviado varchar(50),
    tra_dataEnvio varchar(20),
    dpr_cod int not null,
    fun_cod int not null,
    cod_fun int,
    constraint pk_tra_cod primary key (tra_cod),
    constraint fk_tra_dpr_cod foreign key (dpr_cod) references Dpr_DetalheProcesso (dpr_cod),
    constraint fk_tra_fun_cod foreign key (fun_cod) references Fun_Funcionario (fun_cod)
);

create table Obs_Observacao(
	obs_cod int auto_increment,
    obs_valor varchar(300) not null,
    obs_dataObservacao varchar(50) not null,
    tra_cod int not null,
    fun_cod int not null,
    constraint pk_obs_cod primary key (obs_cod),
    constraint fk_obs_tra_cod foreign key (tra_cod) references Tra_Tramitacao (tra_cod),
    constraint fk_obs_fun_cod foreign key (fun_cod) references Fun_Funcionario (fun_cod)
);

create table Con_Contato(
	con_cod int auto_increment,
	con_tipo enum('Email', 'Telefone', 'Celular') not null,
    con_valor varchar(45) not null,
    pes_cod int not null,
    cod_fun int,
	constraint pk_con_cod primary key (con_cod),
    constraint fk_pes_con foreign key (pes_cod) references Pes_Pessoa (pes_cod)
);

create table Mod_Modulo(
	mod_cod int auto_increment,
    mod_descricao varchar(45) not null,
    mod_pagina varchar(50),
    mod_padrao tinyint(1) not null,
    cod_fun int,
    constraint pk_mod_cod primary key (mod_cod)
);

create table Fun_Mod(
	fun_cod int not null,
    mod_cod int not null,
    cod_fun int,
    constraint pk_fun_mod_cod primary key (fun_cod, mod_cod),
    constraint fk_fun_mod_fun_cod foreign key (fun_cod) references Fun_Funcionario (fun_cod),
    constraint fk_fun_mod_mod_cod foreign key (mod_cod) references Mod_Modulo (mod_cod)
);
