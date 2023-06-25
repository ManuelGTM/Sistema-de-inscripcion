# Sistema-de-inscripcion

#Archivos y actualizaciones del sistema de inscripcion

**Manuel Gabriel Torres Malena ( 20-1346 )**\
**Fracisco Alberto Espino ( 17-0470 )**\
**Abimael Acosta ( 16-0742 )**

# Pasos para usar git y github 

## Comandos para configurar git y github por el metodo SSH

1. Creacion de una cuenta en github  
   [Github](https://github.com/) 

2. Descargar git bash  
   [GitBash](https://github.com/git-for-windows/git/releases/download/v2.41.0.windows.1/Git-2.41.0-64-bit.exe)

### Comandos basicos de git para activar github y git en tu computador

OJO: Todos estos comandos se deben ejecutar por git bash 

1. Informacion personal
- El nombre de usuario y el email van entre comillas dobles

```
git config --global user.name "Tu nombre de usuario"  
git config --global user.email "Email usado en la cuenta de github"
```
2. Cambiar el nombre de la rama master a main

``` 
git config --global init.defaultBranch main
```

3. Activar los colores de la terminal

```
git config --global color.ui auto
```
4. Configurar el comportamiento de la rama principal

```
git config --global pull.rebase false
```
5. Confirmar si todo esta funcionando correctamente
- Se debe correr uno a la vez y este debe devolver tu nombre de usuario y el email de github.
```
git config --get user.name

-- enter y luego este

git config --get user.email
```
6. Creacion de la llave SSH
- Copiar el comando pero reemplazar el email de ejemplo con tu email

```
ssh-keygen -t ed25519 -C Tuemail@email.com  <- remplazalo con tu email de github
```
- te dira que lo guardes en un lugar, pero solo dale a enter hasta que te deje salir

7. Copiar tu llave ssh

```
cat ~/.ssh/id_ed25519.pub
```
- Te debera salir una llave criptografica con tu email al final como esta: 
```
ssh-ed25519 AAAAC3NzaC1SRSTRSTRSTSRTiQBc4P21jkXqasrtasrtdars3417yy1349877132M tuemail@email.com
```
- Copia esa llave con en email tambien
  
8. Ir a Github y guardar la llave

- [GitHub](https://github.com/settings/keys)
   
  ### Pulsas el boton de agregar nueva llave  
    
![Screenshot 2023-06-24 223403](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/1e98c902-8e5d-43ea-8d0b-be85e96d2db7)    


### Pon un nombre a tu llave, pega la llave criptografica y la guardas  

![Screenshot 2023-06-24 224255](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/5584f700-020d-4ec2-a3da-5d10761d8c1b)

### Tu llave ha sido guardada con exito 

![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/f89f42f1-f93d-47a5-aa6f-24e1edeec940)


9. Prueba de la llave SSH
```
ssh -T git@github.com
```
Te debera salir:

> The authenticity of host 'github.com (IP ADDRESS)' can't be established.
> ED25519 key fingerprint is SHA256:+DiY3wvvV6TuJJhbpZisF/zLDA0zPMSvHdkr4UvCOqU.
> Are you sure you want to continue connecting (yes/no)?  <-- Le escribes yes  

Y te saldra esto:  

> Hi (Tu nombre de usuario) You've successfully authenticated, but GitHub does not provide shell access.

Si esto salio, significa que has conectado con exito tu computador con github por el metodo SSH


## Pasos para clonar un repositorio y realizar cambios

1. Copiar el enlace SSH del repositorio

  - Ir al boton que es de color verde que dice code   
  - Ojo: Dentro hay varias opciones pero elije la opcion SSH y copia el enlace

  ![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/0515773d-e20c-4e20-918e-7dec1c22d6cd)

2. Crear una carpeta destinada a guardar el repositorio

 Dentro de git bash ejecuta estos comandos
 
 ```
cd ~            <-- ir a la direccion principal
mkdir repos     <-- creacion de una carpeta --> mkdir ( make directory ) = Crear carpeta
cd repos/       <-- entrar a la carpeta creada --> cd ( change directory ) = cambiar de carpeta
```
  
![Screenshot 2023-06-24 230915](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/12675a27-8925-4035-9464-d6c20a9ca108)

- Si te das cuenta debe aparecer el nombre de tu carpeta en el lado derecho, esto significa que estas dentro de la carpeta deseada

  
3. Clonar el repositorio en la carpeta

   Ejecuta este comando

```
git clone  ( Aqui va el enlace que copiaste )
```
![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/49b3b2d9-9db6-49b8-a207-66327f3d21b0)

```
ls  <--- Comando para ver los archivos dentro de la carpeta
```

- Te saldra algo como esto y de esta manera ya tienes el repositorio clonado dentro de tu computadora y
listo para ser modificado

![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/96b0d632-ea18-4d53-93f7-6b41d28abf71)

## Hacer modificaciones y subirlas al repositorio

Ojo: Debes entrar a la carpeta del repositorio con cd

```
cd ( nombre de la carpeta )
```
![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/133294d5-8abc-4aca-983d-cf2b1fb5349d)


1. Ejecutar este comando cada vez que hagas un cambio en los archivos
   ```
   git status
   ```
   - Este comando se usa para ver el estado de los archivos

![Screenshot 2023-06-24 232321](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/3b1e310a-0bf3-4d9b-a73b-73d4a7de8926)

  - Como puedes ver el archivo esta de color rojo lo cual significa que ha sido modificado o creado pero no esta listo para
  ser enviado

2. Agregar este archivo al area de envio

   ```
   git add .
   ```
- Este comando se usa para agregar los archivos al area de envio  

Luego ejecutamos de nuevo ``git status`` para verificar el estado de archivo  

![Screenshot 2023-06-24 232746](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/f15b8140-af5a-492a-8da7-073cad83f2ca)  

- Como puedes ver ahora nuestro archivo esta de color verde lo cual significa que esta listo para ser enviado 

3. Guardar nuestro archivo en nuestro repositorio local

```
git commit -m "Un mensaje explicando lo que agregaste"
```
![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/0b2ff51f-2f00-4465-8169-f3b0f396141f)

Luego ejecutamos de nuevo ``git status`` para verificar el estado de archivo  

![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/591bf1bc-0b3b-4bb4-9348-9bc77f0bdf81)

Esto significa que el archivo ha sido guardado en el repositorio local y ya no hay mas nada que agregar

4. Consultamos el historial de commits

   ```
   git log 
   ```
  ![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/6ddf7e10-03ab-47c4-bc0e-25f1132054c2)


  - Al ejecutar este comando tendremos un reporte de todos los commits que hayamos realizado
  - Tambien nos muestra quien fue el autor de este y cuando lo subio
  - Para salir de este modo se presiona la letra __q__


5. Enviar nuestro cambios al repositorio

   ```
   git push origin main
   ```  
  ![image](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/12d01bd9-4c71-41e0-b069-8bee12362388)
  
  - Con este comando enviamos todo los cambios a nuestro repositorio

  - Y para ver nuestro archivo vamos al repositorio en github y confirmamos

    ![Screenshot 2023-06-24 234421](https://github.com/ManuelGTM/Sistema-de-inscripcion/assets/131934866/8b7fa2e0-9998-42f6-ba66-afaeb2073879)

    Y aqui esta nuestro archivo en el repositorio guardado y seguro


  6. Obtener los archivos modificados por un comapanero

     ```
     git pull origin main
     ```

     Con esto obtenemos los archivos que han sido cambiados por otro contribuidor y obtenemos sus cambios.
