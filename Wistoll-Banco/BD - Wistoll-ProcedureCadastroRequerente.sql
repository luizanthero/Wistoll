delimiter |
	
    create procedure CadastroRequerente(
		in vPes_nome varchar(45),
        in vPes_sobrenome varchar(45),
        in vPes_dataNascimento varchar(20),
		in vPes_rua varchar(45),
		in vPes_numero varchar(45),
		in vPes_complemento varchar(45),
		in vPes_bairro varchar(45),
		in vPes_cep varchar(45),
		in vPes_cidade varchar(45),
		in vPes_estado varchar(45),
		in vPes_rg varchar(45),
		in vPes_cpf varchar(45),
		in vPes_sexo varchar(45),
        in vPes_cnpj varchar(45), 
        in vPes_sigla varchar(45),
        in vPes_razaoSocial varchar(45),
		in vPes_tipo varchar(45),
		in vPes_ativo varchar(45),
        in vPes_fun int,
        
        in vReq_fun int,
        
        in listaContato text
    )
    
    begin
    
		declare rPessoa int;
		declare excessao smallint default 0;
        declare idPessoa int;
        declare idFuncionario int;
        declare continue handler for sqlexception set excessao = 1;
        
        start transaction;
        
        insert into pes_pessoa values
		(0, vPes_nome, vPes_sobrenome, vPes_dataNascimento, vPes_rua, vPes_numero, vPes_complemento, vPes_bairro, vPes_cep, vPes_cidade, vPes_estado, vPes_rg, vPes_cpf, vPes_sexo, vPes_cnpj, vPes_sigla, vPes_razaoSocial, vPes_tipo, vPes_ativo, vPes_fun); 
		set idPessoa = last_insert_id();
        
        if(excessao = 0) then 
			
            set @sql1 = concat('insert into con_contato values ', listaContato);
            set @sql2 = replace(@sql1, 'pes_con', idPessoa);
            prepare temp from @sql2;
            execute temp;
            deallocate prepare temp;
            
            if(excessao = 0) then
            
				insert into req_requerente values
				(0, idPessoa, vReq_fun);
            
				if(excessao = 0) then
					
                    select 'Cadastro evetuado com Sucesso' as retorno;
					commit;
                    
                else
					select 'Erro ao inserir Requerente' as retorno;
					rollback;
				end if;
			else
				select 'Erro ao inserir contato' as retorno;
				rollback;
			end if;
            
		else
			select 'Erro ao inserir pessoa' as retorno;
			rollback;
		end if;
        
    end
    
    
| delimiter ;

-- drop procedure CadastroRequerente;