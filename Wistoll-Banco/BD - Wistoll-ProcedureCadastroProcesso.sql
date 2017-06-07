delimiter |
	
    create procedure CadastroProcesso(
		in vPro_numeroProcesso varchar(45),
        in vPro_dataPedido varchar(45),
        in vPro_Ativo varchar(20),
		in vPro_mrq int,
		in vPro_req int,
		in vPro_sta int,
		in vPro_fun int,
        
		in vFun_cod int,
		in vPfu_fun int,
        
		in vDpr_dataFinalizar varchar(45),
		in vDpr_fun int,
        
        in vTra_localAtual varchar(45), 
        in vTra_localAnterior varchar(45),
        in vTra_localEnviado varchar(45),
		in vTra_dataEnvio varchar(45),
        in vTra_fun int,
		in vTra_cfu int
    )
    
    begin
    
		declare excessao smallint default 0;
        declare idProcesso int;
        declare idDetalheProcesso int;
        declare continue handler for sqlexception set excessao = 1;
        
        start transaction;
        
        insert into pro_processo values (0, vPro_numeroProcesso, vPro_dataPedido, vPro_Ativo, vPro_mrq, vPro_req, vPro_sta, vPro_fun);
        set idProcesso = last_insert_id();
        
        if(excessao = 0) then 
			
            insert into pro_fun values (vFun_cod, idProcesso, vPfu_fun);
            
            if(excessao = 0) then
            
				insert into dpr_detalheProcesso values (0, vDpr_dataFinalizar, idProcesso, vDpr_fun);
                set idDetalheProcesso = last_insert_id();
            
				if(excessao = 0) then
					
                    insert into tra_tramitacao values (0, vTra_localAtual, vTra_localAnterior, vTra_localEnviado, vTra_dataEnvio, idDetalheProcesso, vTra_fun, vTra_cfu);
					
                    if(excessao = 0) then
						select 'Cadastro evetuado com Sucesso' as retorno;
						commit;
					else
						select 'Erro ao inserir tramitação' as retorno;
                        rollback;
					end if;
                else
					select 'Erro ao inserir detalhes do processo' as retorno;
                    rollback;
				end if;
			else
				select 'Erro ao inserir processo funcionario' as retorno;
				rollback;
			end if;
            
		else
			select 'Erro ao inserir processo' as retorno;
			rollback;
		end if;
        
    end
    
    
| delimiter ;

-- drop procedure CadastroProcesso;