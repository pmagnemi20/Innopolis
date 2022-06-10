#  4.5 Gitlab-ci, сборка проектов с предыдущих блоков на облачных ранерах, деплой проектов на дев/прод

Свой dotnet проект я закинул в папку src, моя репа [тут](https://gitlab.com/xokage/exchangeservice/-/tree/main).
Пайплайн когда все проходит успешно на ветке main [тут](https://gitlab.com/xokage/exchangeservice/-/pipelines/561141798).
Пайплайн когда я меняю в ямлике переменную TEST_VALUE на значение 1, чтобы не пройти тест, тогда следующие джобы не запускаются, можно посмотреть [здесь](https://gitlab.com/xokage/exchangeservice/-/pipelines/561127398).
Пайплайн когда я прогоняю джобы на ветке test-1, тогда ручной запуск Deploy не доступен, можно посмотреть [тут](https://gitlab.com/xokage/exchangeservice/-/pipelines/561145768).