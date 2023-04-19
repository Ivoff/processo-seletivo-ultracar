Olá, não consegui terminar a tempo. A aplicação tem quatro componentes: o banco, que deve estar online no momento de da execução, o serviço de geração de qrcodes, a API principal e finalmente o frontend.
## Fluxo
O fluxo da aplicação era para seguir de forma que: o cliente acessasse o qrcode pela a ãplicação e o exibisse na tela do celular, o colaborator escaneasse o código apenas acessando a aplicação, com autoridade de colaborador, pelo celular, depois de escanear com sucesso, o serviço seria criado, a partir daí o colaborador pode escolher adicionar peças ou decidir iniciar o serviço, o que daría início a cobtabilização do tempo, apenas após o colaborador sinalizar pela aplicação de que terminou o serviço, o tempo parará de ser contado e o serviço será dado como completo.
## Ordem de execução dos projetos
1. O ``QrcodeGenerator`` não depende de ninguém, então ele precisa pode ser iniciado antes.
2. O ``Database`` precisa estar *up and running* do service manager, que é onde o core do domínio da aplicação está.
3. O ``ServiceManager``vem depois.
4. Finalmente o ``frontend`` é iniciado por último.
## Sobre a facilidade de execução e automação
Não tive tempo de criar dockerfiles para fazer um docker-compose, mas se eu puder apresentar minha aplicação posso esclarecer mais o que eu estava pensando.
## Repositório
https://github.com/Ivoff/processo-seletivo-ultracar