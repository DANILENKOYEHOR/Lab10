Реализовать метод, который в 4 потока заполняет массив из 1 миллиона объектов случайными данными 
(обратите внимание на потенциальные проблемы многопоточности, такие как доступ к разделяемым ресурсам и 
попробуйте решить их, чтобы обеспечить корректную параллельную обработку). 
Общий размер массива и диапазон значений для каждого потока должны быть настраиваемыми параметрами 
(для возможности контроля корректности заполнения): 2 балла.
Реализовать параллельную сортировку массива по выбранному полю 
(используйте многопоточность для разделения массива на подмассивы и их сортировки; в конечном итоге, объедините отсортированные подмассивы в один отсортированный массив): 3 балла.
Создать несколько потоков (например, 4 или 8) и выполнить сортировки параллельно: 1 балл.
Замерить время выполнения сортировки для разного количества потоков и 
сравнить полученные результаты с сортировкой без распараллеливания (сделайте выводы о производительности параллельной сортировки): 1 балл.
Обеспечить корректную обработку исключений и учесть возможные ошибки: 2 балла.
Найти и применить дополнительные способы повышения производительности (указать в комментариях и README, что именно было сделано): 1 балл.