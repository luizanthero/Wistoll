delimiter |
	
create procedure UpdateUsuario(
	in vPes_cod int,
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
	
    in vFun_cod int,
    in vFun_matricula varchar(45),
	in vFun_chefeSetor tinyint(1),
	in vFun_chefeDepartamento tinyint(1),
	in vSet_cod int,
	in vCar_cod int,
	in vPfl_cod int,
    in vFun_fun int,
    
    in listaPermissao text
)
    
    begin
    
		declare rPessoa int;
		declare excessao smallint default 0;
        declare idPessoa int;
        declare idFuncionario int;
        declare continue handler for sqlexception set excessao = 1;
        
        start transaction;
        
        update pes_pessoa set
		pes_nome = vPes_nome, pes_sobrenome = vPes_sobrenome, pes_dataNascimento = vPes_dataNascimento, pes_rua = vPes_rua, 
        pes_numero = vPes_numero, pes_complemento = vPes_complemento, pes_bairro = vPes_bairro, pes_cep = vPes_cep, 
		pes_cidade = vPes_cidade, pes_estado = vPes_estado, pes_rg = vPes_rg, pes_cpf = vPes_cpf, pes_sexo = vPes_sexo, pes_cnpj = vPes_cnpj,
        pes_sigla = vPes_sigla, pes_razaoSocial = vPes_razaoSocial, pes_tipo = vPes_tipo, pes_ativo = vPes_ativo, cod_fun = vPes_fun
        where pes_cod = vPes_cod; 
		set idPessoa = vPes_cod;
        
        if(excessao = 0) then 
            
			update fun_funcionario set fun_matricula = vFun_matricula, fun_chefeSetor = vFun_chefeSetor,
            fun_chefeDepartamento = vFun_chefeDepartamento, set_cod = vSet_cod, car_cod = vCar_cod, pfl_cod = vPfl_cod, cod_fun = vFun_fun
			where fun_cod = vFun_cod;
			set idFuncionario = vFun_cod;
            
			if(excessao = 0) then
					
				delete from fun_mod where fun_cod = idFuncionario;
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
			select 'Erro ao inserir pessoa' as retorno;
			rollback;
		end if;
        
    end
    
    
| delimiter ;

-- drop procedure UpdateUsuario;