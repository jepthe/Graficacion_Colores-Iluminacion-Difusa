#version 330 core
out vec4 FragColor;
  
//variables de entrada desde el 1.color.vs
in vec3 FragPos;
in vec3 Normal;


uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;

void main()
{
    //ambiet lightColor
    float ambientStrenght = 0.1;//fuerza de la luz ambiental
    vec3 ambient = ambientStrenght * lightColor;//la intencidad del ambiente se combina con el color de la luz (blanco)

    // diffuse light
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;

    //specular
    float specularStrength = 1;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir,norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor;

    //Para tener color ambiente (Luz ambiental)
    vec3 result = (ambient + diffuse + specular) * objectColor; //ahora el resultado de ambient se combina con el color del objeto y el resultado que vemos es el color que refleja la luz en el objeto. 
    FragColor = vec4(result, 1.0);                   //diffuse hace que veamos mas intenso la parte del objeto que está mas cerca del laluz, esto haría que veamos sombras en el objeto

}