left to right direction

%% Definición del Actor
actor "Docente\n(Usuario)" as docente

%% Límite del Sistema (La Aplicación de Consola)
package "Sistema de Control Académico (Consola)" {
    
    usecase "1. Agregar Estudiante a Grupo" as UC1
    usecase "2. Registrar Calificaciones" as UC2
    usecase "3. Generar Listado de Notas" as UC3
    usecase "4. Calcular % de Aprobados" as UC4
    usecase "Buscar Grupo / Asignatura" as UC5

}

%% Relaciones principales del Docente con los casos de uso
docente --> UC1
docente --> UC2
docente --> UC3
docente --> UC4

%% Relaciones de Inclusión (Dependencias)
%% Para hacer casi cualquier cosa, el sistema primero debe buscar el grupo
UC1 ..> UC5 : <<include>>
UC2 ..> UC5 : <<include>>
UC3 ..> UC5 : <<include>>
UC4 ..> UC5 : <<include>>
