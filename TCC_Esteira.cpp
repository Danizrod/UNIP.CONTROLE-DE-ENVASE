// inclusão servo motor
#include <Servo.h>
Servo servo;

// leituras digitais
#define esteira1 13
#define esteira2 12
#define atuadorA 11 // parada1
#define atuadorB 10 // parada2
#define atuadorC 9  // rejeição
#define solenoide 8

#define sensorE 7 // capacitivo
#define sensorF 6 // capacitivo
#define sensorG 5 // capacitivo
#define sensorH 4 // capacitivo

#define bomba 3

// sensores
#define sensorA 52 // infra-vermelho
#define sensorB 50 // infra-vermelho
#define sensorC 48 // infra-vermelho
#define sensorD 46 // infra-vermelho

int tamanhoGarrafa = 0; // pequena

//Variaveis de conexão
String inputString = ""; //string bruta passada pelo programa 
String commandString = ""; //string refinada p/ comando
boolean stringComplete = false;

void setup()
{
    Serial.begin(9600);
    
    digitalWrite(esteira2, LOW);
    digitalWrite(atuadorA, HIGH);
    digitalWrite(atuadorB, HIGH);
    servo.attach(2);

    pinMode(sensorA, INPUT);
    pinMode(sensorB, INPUT);
    pinMode(sensorC, INPUT);
    pinMode(sensorD, INPUT);

    pinMode(sensorE, OUTPUT);
    pinMode(sensorF, OUTPUT);
    pinMode(sensorG, OUTPUT);
    pinMode(sensorH, OUTPUT);
}

void loop()
{
    if(stringComplete)
    {
        stringComplete = false;
        getCommand();
        
        if(commandString.equals("GARRAFA200ML"))
        {
            boolean stateGarrafa = getStateGarrafa();
            if(stateGarrafa == true)
            {
                tamanhoGarrafa = 1;
            }
            
        }
        else
        {
            boolean stateGarrafa = getStateGarrafa();
            if(stateGarrafa == true)
            {
                tamanhoGarrafa = 2;
            }
        }

        inputString = "";

        if (ChecagemTanque())
        {
            ComandaBomba();
        }

        if(tamanhoGarrafa != 0)
        {
            // liga esteira
            digitalWrite(esteira1, HIGH);
            Serial.println("Esteira em funcionamento!");
            delay(1000);

            // identifica garrafa na estação de validação
            if (digitalRead(sensorA) != 0)
            {
                digitalWrite(esteira1, LOW);

                // identifica tamanho da garrafa
                if (ValidaGarrafa())
                {
                    digitalWrite(esteira1, HIGH);
                    digitalWrite(esteira2, HIGH);

                    // identifica chegada da garrafa na estação de envase
                    if (digitalRead(sensorC) != 0)
                    {
                        digitalWrite(esteira2, LOW);

                        delay(5000);

                        // inicio do envase
                        ExecutaEnvase();

                        if (digitalRead(sensorD) != 0)
                        {
                            Serial.println("Garrafa envasada!");
                        }
                    }
                }
                else
                {
                    // descarte da garrafa
                    digitalWrite(atuadorC, HIGH);
                    if (digitalRead(sensorB) == 0)
                    {
                        Serial.println("Garrafa descartada!");
                    }
                }
            }
        }
    }
}

bool ValidaGarrafa()
{
    if (tamanhoGarrafa == 1)
    {
        if (digitalRead(sensorB) == 0)
            return true;
    }
    else
    {
        if (digitalRead(sensorB) != 0)
            return true;
    }
}

void ExecutaEnvase()
{
    // garrafa 200mL
    if (tamanhoGarrafa == 1)
    {
        servo.write(180);
        delay(500);

        digitalWrite(solenoide, HIGH);

        if (digitalRead(sensorE) != 0 && digitalRead(sensorF) == 0)
        {
            // Tem o tamanho pequeno e chegou ao fim do envase
            digitalWrite(solenoide, LOW);
            delay(1000);

            digitalWrite(atuadorB, LOW);
            digitalWrite(esteira2, HIGH);
        }
    }
    else
    {
        servo.write(0);
        delay(500);

        digitalWrite(solenoide, HIGH);

        if (digitalRead(sensorF) != 0)
        {
            // Tem o tamanho grande e chegou ao fim do envase
            digitalWrite(solenoide, LOW);
            delay(1000);

            digitalWrite(atuadorB, LOW);
            digitalWrite(esteira2, HIGH);
        }
    }
}

bool ChecagemTanque()
{
    if (digitalRead(sensorG) == 0)
    {
        return true;
    }
}

void ComandaBomba()
{
    digitalWrite(bomba, HIGH);

    if (digitalRead(sensorH) != 0)
    {
        digitalWrite(bomba, LOW);
    }
}

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,12);
  }
}

boolean getStateGarrafa()
{
  boolean state = false;
  if(inputString.substring(5,7).equals("ON"))
  {
    state = true;
  }else
  {
    state = false;
  }
  return state;
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}