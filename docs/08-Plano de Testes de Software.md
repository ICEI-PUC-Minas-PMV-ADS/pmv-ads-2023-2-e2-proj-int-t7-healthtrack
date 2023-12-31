# Plano de Teste do Website HealthTrack

### Introdução

>Este plano de testes detalha a abordagem de testes para o website HealthTrack. O objetivo deste plano é verificar se o website funciona conforme o previsto e está livre de problemas críticos.

### Objetivos

>Confirmar que o website HealthTrack é carregado corretamente.
>Verificar a funcionalidade dos recursos essenciais.
>Assegurar que o website HealthTrack seja visual e funcionalmente consistente nos navegadores e dispositivos mais comuns.

### Escopo
**Este plano de testes abrange o teste do website HealthTrack. Ele inclui:**

>*Teste Funcional*
>Teste em Diferentes Navegadores
>Teste em Dispositivos Móveis
>Ambiente de Teste
>Navegadores: Navegadores com base em Chromium, Fire Fox.
>Dispositivos: PC, Mobile.

### Casos de Teste

 **Teste Funcional**
 
>Verificar se a página inicial do website HealthTrack é carregada sem erros.
>
>Testar o menu de navegação do HealthTrack clicando em cada item do menu.
>
>Testar o formulário de contato do HealthTrack para garantir que as submissões sejam recebidas.
>
>Verificar a renderização correta de imagens e conteúdo multimídia no HealthTrack.
>
>Validar se os links externos no HealthTrack abrem em novas abas ou janelas.
>
>Teste em Diferentes Navegadores
>
>Testar o website HealthTrack nos navegadores especificados (Navegadores com base em Chromium, Fire Fox.).
>
>Assegurar que todos os recursos do HealthTrack funcionem conforme o esperado em cada navegador.
>
>Teste em Dispositivos Móveis
>
>Testar o website HealthTrack em dispositivos móveis especificados (listar os dispositivos aqui).
>
>Confirmar que a versão móvel do HealthTrack é responsiva e amigável ao usuário.

### Cronograma de Testes
>Os testes para o website HealthTrack têm sido contínuos e em andamento desde o início do projeto e continuarão como parte integral do ciclo de vida do projeto.
>Os resultados serão relatados [Especificar a frequência de relatórios].

### Critérios de Aprovação
>**Todos os defeitos críticos devem ser resolvidos e todos os casos de teste devem ser aprovados.**

### Entregas dos Testes
>Relatório de casos de teste e resultados do HealthTrack.
>Um resumo dos problemas críticos encontrados no HealthTrack e suas resoluções.

### Plano de Comunicação
>A comunicação referente aos resultados dos testes e qualquer questão relacionada será restrita aos membros da equipe envolvidos diretamente no projeto HealthTrack.
>Quaisquer problemas críticos encontrados durante os testes no HealthTrack serão documentados e tratados.

### Dependências
>Disponibilidade dos dispositivos e navegadores necessários para os testes.


| Caso de Teste        | CT-01 - Criação de treinos e dietas |
|-----------------------|-------------------------------------|
| Requisitos Associados | RF-01,O site deve apresentar, na página principal, um board para cadastro de exercício físico do usuário,  RF-02 O site deve apresentar, na página principal, um board para cadastro de dieta do usuário. |
| Objetivo do Teste     | Verificar se a ordem de inclusão dos exercícios e alimentos foram respeitadas |
| Passos                | 1) Acessar o Navegador<br>2) Informar o endereço do Site<br>3) Fazer o Cadastro<br>4) Fazer o Log In<br>5) Visualizar a página Home |
| Critérios de Êxito    | Os treinos e dieta devem ser apresentados na ordem correta de inclusão<br>As fontes devem estar visíveis ao usuário |

| Caso de Teste        | CT-02 - Calculo da TMB e IMC        |
|-----------------------|-------------------------------------|
| Requisitos Associados | RF-09 - O site deve permitir Calcular o IMC,  RF-10 O site deve possibilitar o cálculo da Taxa metabólica basal do usuário       |
| Objetivo do Teste     | Verificar se os cálculos estão corretos |
| Passos                | 1) Acessar o Navegador<br>2) Informar o endereço do Site<br>3) Fazer o Log In<br>4) Visualizar a página Perfil |
| Critérios de Êxito    | A página deve apresentar o resultado do cálculo corretamente |


