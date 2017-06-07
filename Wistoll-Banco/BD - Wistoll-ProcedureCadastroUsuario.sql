delimiter |
	
    create procedure CadastroUsuario(
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
        
        in vFun_matricula varchar(45),
		in vFun_senha varchar(300),
		in vFun_chefeSetor tinyint(1),
		in vFun_chefeDepartamento tinyint(1),
		in vSet_cod int,
		in vCar_cod int,
		in vPfl_cod int,
        in vFun_fun int,
        
        in listaContato text,
        in listaPermissao text
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
            
				insert into fun_funcionario(fun_cod, fun_matricula, fun_senha, fun_chefeSetor, fun_chefeDepartamento, set_cod, car_cod, pes_cod, pfl_cod, cod_fun) values
				(0, vFun_matricula, vFun_senha, vFun_chefeSetor, vFun_chefeDepartamento, vSet_cod, vCar_cod, idPessoa, vPfl_cod, vFun_fun);
				set idFuncionario = last_insert_id();
            
				if(excessao = 0) then
					
                    set @sql3 = concat('insert into fun_mod values ', listaPermissao);
                    set @sql4 = replace(@sql3, 'fun_per', idFuncionario);
                    prepare temp1 from @sql4;
                    execute temp1;
                    deallocate prepare temp1;
					
                    if(excessao = 0) then
						select 'Cadastro evetuado com Sucesso' as retorno;
						commit;
					else
						select 'Erro ao inserir permissao' as retorno;
                        rollback;
					end if;
                else
					select 'Erro ao inserir funcionario' as retorno;
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

-- drop procedure CadastroUsuario;