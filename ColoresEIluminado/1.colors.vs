#version 330 core
layout (location = 0) in vec3 aPos;//recibimos la posicion del objeto 
layout (location = 1) in vec3 aNormal;//representa al vector normal

//creamos 2 valores de salida que ocupamos para 1.colors.fs
out vec3 FragPos;
out vec3 Normal;


uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	FragPos = vec3(model * vec4(aPos, 1.0));
	Normal = mat3(transpose(inverse(model))) * aNormal;  //para la luz difusa mat3(traspose(inverse(model)))
	gl_Position = projection * view * vec4(FragPos, 1.0);
}