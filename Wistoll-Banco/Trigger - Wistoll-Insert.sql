delimiter |
	
    create trigger trg_modeloRequerimento_insert 
    after insert on Mrq_ModeloRequerimento
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Modelo Requerimento', new.mrq_descricao, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.mrq_cod, new.mrq_descricao)
        );
    
    end;
    
 | delimiter ;
 
delimiter |
	
    create trigger trg_cargo_insert 
    after insert on Car_Cargo
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Cargo', new.car_descricao, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.car_cod, new.car_descricao)
        );
    
    end;
    
 | delimiter ;
 
delimiter |
	
    create trigger trg_departamento_insert 
    after insert on Dep_Departamento
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Departamento', new.dep_nome, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.dep_cod, new.dep_nome, new.dep_descricao, new.dep_ativo)
        );
    
    end;
    
 | delimiter ;
 
delimiter |
	
    create trigger trg_setor_insert 
    after insert on Set_Setor
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Setor', new.set_nome, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.set_cod, new.set_nome, new.set_descricao, new.set_ativo, new.dep_cod)
        );
    
    end;
    
 | delimiter ;

delimiter |
	
    create trigger trg_pessoa_insert 
    after insert on Pes_Pessoa
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Pessoa', concat_ws(' ', new.pes_nome, new.pes_sobrenome), 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.pes_cod, new.pes_nome, new.pes_sobrenome, new.pes_dataNascimento, new.pes_rua, 
				new.pes_numero, new.pes_complemento, new.pes_bairro, new.pes_cep, new.pes_cidade, new.pes_estado, 
                new.pes_rg, new.pes_cpf, new.pes_sexo, new.pes_cnpj, new.pes_sigla, new.pes_razaoSocial, new.pes_tipo, new.pes_ativo)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_perfil_insert 
    after insert on Pfl_Perfil
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Perfil', new.pfl_descricao, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.pfl_cod, new.pfl_descricao, new.pfl_imagem)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_funcionario_insert 
    after insert on Fun_Funcionario
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Funcionário', new.fun_matricula, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.fun_cod, new.fun_matricula, new.fun_senha, new.fun_chefeSetor, new.fun_chefeDepartamento, 
            new.set_cod, new.car_cod, new.pes_cod, new.pfl_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_requerente_insert 
    after insert on Req_Requerente
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Requerente', new.pes_cod, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.req_cod, new.pes_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_status_insert 
    after insert on Sta_Status
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Status', new.sta_valor, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.sta_cod, new.sta_valor)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_processo_insert 
    after insert on Pro_Processo
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Processo', new.pro_numeroProcesso, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.pro_cod, new.pro_numeroProcesso, new.pro_dataPedido, 
				new.pro_ativo, new.mrq_cod, new.req_cod, new.sta_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_detalheProcesso_insert 
    after insert on Dpr_DetalheProcesso
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Detalhe Processo', new.pro_cod, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.dpr_cod, new.dpr_dataFinalizar, new.pro_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_anexos_insert 
    after insert on Anx_Anexos
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Anexos', new.anx_descricao, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.anx_cod, new.anx_nome, new.anx_descricao, new.dpr_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_proFun_insert 
    after insert on Pro_Fun
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Funcionário Processo', new.fun_cod, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.fun_cod, new.pro_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_tramitacao_insert 
    after insert on Tra_Tramitacao
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Tramitação', new.tra_cod, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.tra_cod, new.tra_localAtual, new.tra_localAnterior, new.tra_localEnviado,
				new.tra_dataEnvio, new.dpr_cod, new.fun_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_observacao_insert 
    after insert on Obs_Observacao
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.fun_cod, 'Observacao', new.obs_cod, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.obs_cod, new.obs_valor, new.obs_dataObservacao, new.tra_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_contato_insert 
    after insert on Con_Contato
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Contato', new.con_cod, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.con_cod, new.con_tipo, new.con_valor, new.pes_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_modulo_insert 
    after insert on Mod_Modulo
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Modulo', new.mod_descricao, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.mod_cod, new.mod_descricao, new.mod_pagina, new.mod_padrao)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_funMod_insert 
    after insert on Fun_Mod
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Funcionário Modulo', new.fun_cod, 'Inserção', now(), 'Inserção', 
            concat_ws(' - ', new.fun_cod, new.mod_cod)
        );
    
    end;
    
 | delimiter ;