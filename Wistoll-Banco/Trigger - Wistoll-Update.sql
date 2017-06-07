delimiter |
	
    create trigger trg_modeloRequerimento_update 
    before update on Mrq_ModeloRequerimento
    for each row
    begin
        
        insert into aud_auditoria values (
			0, new.cod_fun, 'Modelo Requerimento', concat_ws('/', old.mrq_descricao, new.mrq_descricao), 'Atualização', now(), 
            concat_ws(' - ', old.mrq_cod, old.mrq_descricao),
            concat_ws(' - ', new.mrq_cod, new.mrq_descricao)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_cargo_update 
    before update on Car_Cargo
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Cargo', concat_ws('/', old_car_descricao), 'Atualização', now(), 
            concat_ws(' - ', old.car_cod, old.car_descricao),
            concat_ws(' - ', new.car_cod, new.car_descricao)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_departamento_update 
    before update on Dep_Departamento
    for each row
    begin
    
		declare acao varchar(50);
		declare campoNome varchar(50);
    
        if(new.dep_ativo = 'Ativo' and old.dep_ativo = new.dep_ativo) then
			set acao = 'Atualização';
            set campoNome = new.dep_nome;
        else
			if(old.dep_ativo = 'Inativo') then
				set acao = 'Ativação';
				set campoNome = new.dep_nome;
            else
				set acao = 'Exclusão';
				set campoNome = new.dep_nome;
            end if;
        end if;
        
        insert into aud_auditoria values (
			0, new.cod_fun, 'Departamento', campoNome,  acao, now(), 
			concat_ws(' - ', old.dep_cod, old.dep_nome, old.dep_descricao, old.dep_ativo),
			concat_ws(' - ', new.dep_cod, new.dep_nome, new.dep_descricao, new.dep_ativo)
		);
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_setor_update
    before update on Set_Setor
    for each row
    begin
    
		declare acao varchar(50);
		declare campoNome varchar(50);
    
        if(new.set_ativo = 'Ativo' and old.set_ativo = new.set_ativo) then
			set acao = 'Atualização';
            set campoNome = new.set_nome;
        else
			if(old.set_ativo = 'Inativo') then
				set acao = 'Ativação';
				set campoNome = new.set_nome;
			else
				set acao = 'Exclusão';
				set campoNome = new.set_nome;
			end if;
        end if;
        
        insert into aud_auditoria values (
			0, new.cod_fun, 'Setor', campoNome, acao, now(),
            concat_ws(' - ', old.set_cod, old.set_nome, old.set_descricao, old.set_ativo, old.dep_cod),
            concat_ws(' - ', new.set_cod, new.set_nome, new.set_descricao, new.set_ativo, new.dep_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_pessoa_update
    before update on Pes_Pessoa
    for each row
    begin
    
		declare acao varchar(50);
		declare campoNome varchar(50);
    
        if(new.pes_ativo = 'Ativo' and old.pes_ativo = new.pes_ativo) then
			set acao = 'Atualização';
            set campoNome = concat_ws('/', concat_ws(' ', old.pes_nome, old.pes_sobrenome), concat_ws(' ', new.pes_nome, new.pes_sobrenome));
        else
			if(old.pes_ativo = 'Inativo') then
				set acao = 'Ativação';
				set campoNome = 'Ativação';
			else
				set acao = 'Exclusão';
				set campoNome = 'Exclusão';
			end if;
        end if;
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Pessoa', campoNome, acao, now(), 
            concat_ws(' - ', old.pes_cod, old.pes_nome, old.pes_sobrenome, old.pes_dataNascimento, old.pes_rua, 
				old.pes_numero, old.pes_complemento, old.pes_bairro, old.pes_cep, old.pes_cidade, old.pes_estado, 
                old.pes_rg, old.pes_cpf, old.pes_sexo, old.pes_cnpj, old.pes_sigla, old.pes_razaoSocial, old.pes_tipo, old.pes_ativo),
			concat_ws(' - ', new.pes_cod, new.pes_nome, new.pes_sobrenome, new.pes_dataNascimento, new.pes_rua, 
				new.pes_numero, new.pes_complemento, new.pes_bairro, new.pes_cep, new.pes_cidade, new.pes_estado, 
                new.pes_rg, new.pes_cpf, new.pes_sexo, new.pes_cnpj, new.pes_sigla, new.pes_razaoSocial, new.pes_tipo, new.pes_ativo)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_perfil_update 
    before update on Pfl_Perfil
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Perfil', concat_ws('/', old.pfl_descricao, new.pfl_descricao), 'Atualização', now(),
            concat_ws(' - ', old.pfl_cod, old.pfl_descricao, old.pfl_imagem),
            concat_ws(' - ', new.pfl_cod, new.pfl_descricao, new.pfl_imagem)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_funcionario_update 
    before update on Fun_Funcionario
    for each row
    begin
    
		declare acao varchar(50);
		declare campoNome varchar(50);
    
        if(new.fun_senha = old.fun_senha) then
			set acao = 'Atualização';
            set campoNome = concat_ws('/', old.fun_matricula, new.fun_matricula);
        else
			set acao = 'Alteração de Senha';
            set campoNome = concat_ws('/', old.fun_matricula, new.fun_matricula);
        end if;
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Funcionário', campoNome, acao, now(), 
            concat_ws(' - ', old.fun_cod, old.fun_matricula, old.fun_senha, old.fun_chefeSetor, old.fun_chefeDepartamento, 
            old.set_cod, old.car_cod, old.pes_cod, old.pfl_cod),
            concat_ws(' - ', new.fun_cod, new.fun_matricula, new.fun_senha, new.fun_chefeSetor, new.fun_chefeDepartamento, 
            new.set_cod, new.car_cod, new.pes_cod, new.pfl_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_requerente_update
    before update on Req_Requerente
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Requerente', concat_ws('/', old.pes_cod, new.pes_cod), 'Atualização', now(), 
            concat_ws(' - ', old.req_cod, old.pes_cod),
            concat_ws(' - ', new.req_cod, new.pes_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_status_update
    before update on Sta_Status
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Status', concat_ws('/', old.sta_valor, new.sta_valor), 'Atualização', now(), 
            concat_ws(' - ', old.sta_cod, old.sta_valor),
            concat_ws(' - ', new.sta_cod, new.sta_valor)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_processo_update 
    before update on Pro_Processo
    for each row
    begin
    
		declare acao varchar(50);
		declare campoNome varchar(50);
    
        if(new.pro_ativo = 'Ativo') then
			set acao = 'Atualização';
            set campoNome = concat_ws('/', old.pro_numeroProcesso, new.pro_numeroProcesso);
        else
			if(old.pro_ativo = 'Inativo') then
				set acao = 'Ativação';
				set campoNome = 'Ativação';
			else
				set acao = 'Exclusão';
				set campoNome = 'Exclusão';
            end if;
        end if;
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Processo', campoNome, acao, now(), 
            concat_ws(' - ', old.pro_cod, old.pro_numeroProcesso, old.pro_dataPedido, 
				old.pro_ativo, old.mrq_cod, old.req_cod, old.sta_cod),
			concat_ws(' - ', new.pro_cod, new.pro_numeroProcesso, new.pro_dataPedido, 
				new.pro_ativo, new.mrq_cod, new.req_cod, new.sta_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_detalheProcesso_update
    before update on Dpr_DetalheProcesso
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Detalhe Processo', concat_ws('/', old.pro_cod, new.pro_cod), 'Atualização', now(), 
            concat_ws(' - ', old.dpr_cod, old.dpr_dataFinalizar, old.pro_cod),
            concat_ws(' - ', new.dpr_cod, new.dpr_dataFinalizar, new.pro_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_anexos_update 
    before update on Anx_Anexos
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Anexos', concat_ws('/', old.anx_descricao, new.anx_descricao), 'Atualização', now(), 
            concat_ws(' - ', old.anx_cod, old.anx_nome, old.anx_descricao, old.dpr_cod),
            concat_ws(' - ', new.anx_cod, new.anx_nome, new.anx_descricao, new.dpr_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_proFun_update
    before update on Pro_Fun
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Funcionário Processo', concat_ws('/', old.fun_cod, new.fun_cod), 'Atualização', now(), 
            concat_ws(' - ', old.fun_cod, old.pro_cod),
            concat_ws(' - ', new.fun_cod, new.pro_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_tramitacao_update
    before update on Tra_Tramitacao
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Tramitação', concat_ws('/', old.tra_localAtual, new.tra_localAtual), 'Atualização', now(), 
            concat_ws(' - ', old.tra_cod, old.tra_localAtual, old.tra_localAnterior, old.tra_localEnviado,
				old.tra_dataEnvio, old.dpr_cod, old.fun_cod),
			concat_ws(' - ', new.tra_cod, new.tra_localAtual, new.tra_localAnterior, new.tra_localEnviado,
				new.tra_dataEnvio, new.dpr_cod, new.fun_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_observacao_update 
    after update on Obs_Observacao
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.fun_cod, 'Observacao', concat_ws('/', old.obs_dataObservacao, new.obs_dataObservacao), 'Atualização', now(),
            concat_ws(' - ', old.obs_cod, old.obs_valor, old.obs_dataObservacao, old.tra_cod),
            concat_ws(' - ', new.obs_cod, new.obs_valor, new.obs_dataObservacao, new.tra_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_contato_update
    before update on Con_Contato
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Contato', new.pes_cod, 'Atualização', now(), 
            concat_ws(' - ', old.con_cod, old.con_tipo, old.con_valor, old.pes_cod),
            concat_ws(' - ', new.con_cod, new.con_tipo, new.con_valor, new.pes_cod)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_modulo_update 
    before update on Mod_Modulo
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Modulo', concat_ws('/', old.mod_descricao, new.mod_descricao), 'Atualização', now(), 
            concat_ws(' - ', old.mod_cod, old.mod_descricao, old.mod_pagina, old.mod_padrao),
            concat_ws(' - ', new.mod_cod, new.mod_descricao, new.mod_pagina, new.mod_padrao)
        );
    
    end;
    
 | delimiter ;
 
 delimiter |
	
    create trigger trg_funMod_update
    before update on Fun_Mod
    for each row
    begin
		
        insert into aud_auditoria values (
			0, new.cod_fun, 'Funcionário Modulo', concat_ws('/', old.fun_cod, new.fun_cod), 'Atualização', now(), 
            concat_ws(' - ', old.fun_cod, old.mod_cod),
            concat_ws(' - ', new.fun_cod, new.mod_cod)
        );
    
    end;
    
 | delimiter ;