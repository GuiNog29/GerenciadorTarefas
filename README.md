# GerenciadorTarefas

## Processo para executar o sistema

1. Necessário ter programa SQL Server Management Studio para poder olhar o banco de dados.
2. Baixar arquivo `.zip` -> Extrair -> Abrir solução.
3. Executar no terminal `dotnet build` para atualizar todas as dependências.
4. Navegar até a pasta `GerenciadorTarefas.Infrastructure`.
5. Executar `Update-Database` para criar o banco e tabelas.
6. Executar sistema utilizando profile de `GerenciadorTarefas`.

## Fase 2: Refinamento

### Perguntas para o PO

1. **Autenticação e Autorização:**
   - Existe algum plano para implementar autenticação e autorização no futuro? Se sim, quais são os requisitos específicos?

2. **Logs e Monitoramento:**
   - Quais são as expectativas em termos de logs e monitoramento para a aplicação? Devemos integrar algum serviço específico de monitoramento?

3. **Desempenho:**
   - Existem metas de desempenho específicas que devemos alcançar? Há algum benchmark ou teste de carga planejado?

4. **Escalabilidade:**
   - Quais são os planos para a escalabilidade da aplicação? Deveríamos considerar a implementação de microserviços ou outras arquiteturas para facilitar a escalabilidade?

5. **Integrações Futuras:**
   - Há alguma integração planejada com outros sistemas ou serviços que deveríamos preparar?

6. **Padrões de Código:**
   - Existe algum padrão de código ou convenção que você gostaria que seguíssemos além das práticas atuais?

7. **Documentação:**
   - Qual o nível de detalhe esperado na documentação do código e dos endpoints da API?

8. **Feedback de Usuário:**
   - Como será coletado e tratado o feedback dos usuários finais? Devemos implementar alguma ferramenta ou processo para isso?

9. **Segurança:**
   - Existem preocupações específicas de segurança que devemos considerar na fase atual ou em futuras implementações?

10. **Melhorias no Processo de Desenvolvimento:**
    - Há alguma sugestão de melhoria no nosso atual processo de desenvolvimento ou fluxo de trabalho que deveríamos adotar?

## Fase 3: Final

### Melhorias Propostas

1. **Implementação de Autenticação e Autorização:**
   - Implementar políticas de autorização baseadas em roles e claims.

2. **Melhoria na Arquitetura:**
   - Considerar a adoção de uma arquitetura de **microserviços** para melhorar a escalabilidade e a manutenção do código.

3. **Monitoramento e Logging:**
   - Utilizar **Serilog** para logging estruturado e fácil integração com diversos sistemas de logs.

4. **Testes e Qualidade de Código:**
   - Aumentar a cobertura de testes unitários e de integração para pelo menos 90%.
   - Implementar **testes de carga** e **testes de performance** para garantir que a aplicação suporta a carga esperada.

5. **Documentação:**
   - Melhorar a documentação dos endpoints da API utilizando **Swagger** e **OpenAPI**.
   - Criar documentação detalhada para desenvolvedores, incluindo guias de contribuição e configuração do ambiente de desenvolvimento.

6. **Automação e CI/CD:**
   - Configurar pipelines de **CI/CD** utilizando **GitHub Actions** ou **Azure DevOps**.
   - Automação dos testes e deploys para garantir maior agilidade e confiabilidade nas entregas.

7. **Melhorias na Interface do Usuário:**
   - Realizar pesquisas de usabilidade para melhorar a experiência do usuário.
   - Implementar um design responsivo utilizando frameworks modernos como **React** ou **Angular**.

8. **Desempenho:**
   - Otimizar consultas ao banco de dados e considerar o uso de **cache** para dados frequentemente acessados.

9. **Integrações Futuras:**
    - Preparar a aplicação para futuras integrações com APIs de terceiros, garantindo que a arquitetura suporte essa extensibilidade.

