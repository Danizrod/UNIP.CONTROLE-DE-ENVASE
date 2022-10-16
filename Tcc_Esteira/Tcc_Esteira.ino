// leituras digitais
#define atuadorA 11 // parada1
#define atuadorB 10 // parada2
#define atuadorC 9  // rejeição
#define solenoide 8

// esteira1
#define pinoPWM 4
int vel = 0;

// esteira2
#define velmotor 7
#define mla 6
#define mlb 5
int vel2 = 0;

#define bomba 3

// sensores
#define sensorA 52 // infra-vermelho
#define sensorB 50 // infra-vermelho
#define sensorC 48 // infra-vermelho
#define sensorD 46 // infra-vermelho

#define sensorE 44 // capacitivo
#define sensorG 40 // capacitivo
#define sensorH 38 // capacitivo

int tamanhoGarrafa = 0; // pequena

// Variaveis de conexão
String inputString = "";   // string bruta passada pelo programa
String commandString = ""; // string refinada p/ comando
boolean stringComplete = false;

void setup()
{
    Serial.begin(9600);

    digitalWrite(atuadorA, LOW);
    digitalWrite(atuadorB, HIGH);

    pinMode(sensorA, INPUT);
    pinMode(sensorB, INPUT);
    pinMode(sensorC, INPUT);
    pinMode(sensorD, INPUT);

    pinMode(sensorE, OUTPUT);
    pinMode(sensorG, OUTPUT);
    pinMode(sensorH, OUTPUT);

    pinMode(velmotor, OUTPUT);
    pinMode(mla, OUTPUT);
    pinMode(mlb, OUTPUT);
    analogWrite(velmotor, vel2);

    pinMode(pinoPWM, OUTPUT);
}

void loop()
{
    //EMERGENCIA PRA NAO MOLHAR A CASA DO NETAO
    //digitalWrite(solenoide, LOW);  

    if (ChecagemTanque())
    {
        ComandaBomba();
    }

    if (stringComplete)
    {
        stringComplete = false;
        getCommand();

        if (commandString.equals("GARRAFA200ML"))
        {
            boolean stateGarrafa = getStateGarrafa();
            if (stateGarrafa == true)
            {
                tamanhoGarrafa = 1;
            }
        }
        else if (commandString.equals("GARRAFA300ML"))
        {
            boolean stateGarrafa = getStateGarrafa();
            if (stateGarrafa == true)
            {
                tamanhoGarrafa = 2;
            }
        }
        else if (commandString.indexOf("ESTEIRA") != -1)
        {
            Serial.println("inputString: " + inputString);
            Serial.println("commandString: " + commandString);
            SetaVelocidadeEsteiras();
        }
        
        inputString = "";

        if (tamanhoGarrafa != 0)
        {
            // liga esteira
            ComandaEsteira(1, 1);
            delay(1000);

            // identifica garrafa na estação de validação
            if (digitalRead(sensorA) != 0)
            {
                ComandaEsteira(1, 0);

                // identifica tamanho da garrafa
                if (ValidaGarrafa())
                {
                    ComandaEsteira(1, 1);
                    ComandaEsteira(2, 1);

                    // identifica chegada da garrafa na estação de envase
                    if (digitalRead(sensorC) != 0)
                    {
                        ComandaEsteira(2, 0);

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

void SetaVelocidadeEsteiras()
{
  
    if (commandString.indexOf("ESTEIRA1") != -1)
    {
        if (commandString.indexOf("V1") >= 0)
        {
            vel = 70;
            ComandaEsteira(1, 1);
        }
        else if (commandString.indexOf("V2") >= 0)
        {
            vel = 150;
            ComandaEsteira(1, 1);
        }
        else if (commandString.indexOf("V3") >= 0)
        {
            vel = 255;
            ComandaEsteira(1, 1);
        }
        else
        {
            vel = 0;
            ComandaEsteira(1, 0);
        }
    }
    else if (commandString.indexOf("ESTEIRA2") != 1)
    {
        Serial.println(commandString.indexOf("ESTEIRA2"));
        Serial.println(commandString.indexOf("V3"));
        if (commandString.indexOf("V1") != -1)
        {
            vel2 = 50;
            ComandaEsteira(2, 1);
        }
        else if (commandString.indexOf("V2") != -1)
        {
            vel2 = 70;
            ComandaEsteira(2, 1);
        }
        else if (commandString.indexOf("V3") != -1)
        {
            vel2 = 90;
            ComandaEsteira(2, 1);
        }
        else
        {
            vel2 = 0;
            ComandaEsteira(2, 0);
        }
    }
}

void ExecutaEnvase()
{
    // garrafa 200mL
    if (tamanhoGarrafa == 1)
    {
        digitalWrite(solenoide, HIGH);
        long int t1 = millis();
        delay(3000);
        long int t2 = millis();

        if (digitalRead(sensorE) != 0 || t2 - t1 > 3000)
        {
            // Tem o tamanho pequeno e chegou ao fim do envase
            digitalWrite(solenoide, LOW);
            delay(1000);

            digitalWrite(atuadorB, LOW);
            delay(1000);
            digitalWrite(atuadorA, LOW);

            ComandaEsteira(2, 1);
        }
    }
    else
    {
        digitalWrite(solenoide, HIGH);
        long int t1 = millis();
        delay(5000);
        long int t2 = millis();

        if (digitalRead(sensorE) != 0 || t2 - t1 > 5000)
        {
            // Tem o tamanho grande e chegou ao fim do envase
            digitalWrite(solenoide, LOW);
            delay(1000);

            digitalWrite(atuadorB, LOW);
            delay(1000);
            digitalWrite(atuadorA, LOW);

            ComandaEsteira(2, 1);
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
    if (inputString.length() > 0)
    {
        if (inputString.indexOf("GARRAFA") != -1)
        {
            commandString = inputString.substring(1, 12);
        }
        else if (inputString.indexOf("ESTEIRA") != -1)
        {
            commandString = inputString.substring(1, 11);
        }
    }
}

void ComandaEsteira(int esteira, bool comando)
{
    if (esteira == 1)
    {
       if (comando == 1)
        {
            analogWrite(pinoPWM, vel);
        }
        else
        {
            analogWrite(pinoPWM, 0);
        }
    }
    else
    {
        if (comando == 1)
        {
            analogWrite(velmotor, vel2);

            digitalWrite(mla, HIGH);
            digitalWrite(mlb, LOW);
        }
        else
        {
            digitalWrite(mla, LOW);
            digitalWrite(mlb, LOW);
        }
        
        
    }
}

boolean getStateGarrafa()
{
    boolean state = false;
    if (inputString.substring(5, 7).equals("ON"))
    {
        state = true;
    }
    else
    {
        state = false;
    }
    return state;
}

void serialEvent()
{
    while (Serial.available())
    {
        char inChar = (char)Serial.read();
        inputString += inChar;
        if (inChar == '\n')
        {
            stringComplete = true;
        }
    }
}