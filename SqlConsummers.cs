        //parametro return
		private T ConverterValor<T>(SqlDataReader rdr, string nome)
        {
            try
            {
                if (rdr[nome] == DBNull.Value)
                    return default;
                else
                {
                    object value = rdr[nome];

                    Type t = typeof(T);
                    t = Nullable.GetUnderlyingType(t) ?? t;

                    return (value == null || DBNull.Value.Equals(value)) ?
                        default : (T)Convert.ChangeType(value, t);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"N�o foi poss�vel converter o valor retornado do SqlServer para a coluna: {nome}, mensagem: {ex.Message}");
            }
        }
		//ex call
		retorno = ConverterValor<string>(rdr, "numero");
		
		
		//parametro reader
		private void AddParametro(SqlCommand cmd, string nome, object parametro)
        {
            if (parametro == null)
                cmd.Parameters.AddWithValue(nome, DBNull.Value);
            else
                cmd.Parameters.AddWithValue(nome, parametro);
        }
		//ex call
        AddParametro(cmd, "@codigo", codigo);
		