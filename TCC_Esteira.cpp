// leituras digitais
#define atuadorA 11 // parada1
#define atuadorB 10 // parada2
#define atuadorC 9  // rejeição
#define solenoide 8

// esteira1
#define velmotor1 4
#define mla1 3
#define mlb1 2
int vel1 = 0;
bool esteira1Ligada = false;

// esteira2
#define velmotor2 7
#define mla2 6
#define mlb2 5
int vel2 = 0;
bool esteira2Ligada = false;

#define bomba 12
bool emEnvase = false;

// sensores
#define sensorA 52 // infra-vermelho
#define sensorB 50 // infra-vermelho
#define sensorC 48 // infra-vermelho
#define sensorD 46 // infra-vermelho

#define sensorE 44 // capacitivo
#define sensorF 42 // capacitivo
#define sensorG 40 // capacitivo

int tamanhoGarrafa = 0; // 0 é nenhuma, 1 é pequena e 2 é grande

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
    pinMode(sensorF, OUTPUT);
    pinMode(sensorG, OUTPUT);

    pinMode(velmotor1, OUTPUT);
    pinMode(mla1, OUTPUT);
    pinMode(mlb1, OUTPUT);
    analogWrite(velmotor1, vel1);

    pinMode(velmotor2, OUTPUT);
    pinMode(mla2, OUTPUT);
    pinMode(mlb2, OUTPUT);
    analogWrite(velmotor2, vel2);
}

void loop()
{
    // EMERGENCIA PRA NAO MOLHAR A CASA DO NETAO
    // digitalWrite(solenoide, LOW);

    if (ChecagemTanque())
    {
        ComandaBomba();
    }

    if (stringComplete)
    {
        RecebeComandos();
    }

    // Processo
    if (tamanhoGarrafa != 0)
    {
        // liga esteira
        if (!esteira1Ligada)
        {
            ComandaEsteira(1, 1);
        }

        // identifica garrafa na estação de validação
        if (digitalRead(sensorA) != 0)
        {

            if (esteira1Ligada)
            {
                ComandaEsteira(1, 0);
            }

            ValidacaoDescarte();
        }

        // identifica chegada da garrafa na estação de envase
        if (digitalRead(sensorC) != 0)
        {
            if (esteira2Ligada)
            {
                ComandaEsteira(2, 0);
            }

            ExecutaEnvase();

            if (digitalRead(sensorD) != 0)
            {
                Serial.println("Garrafa envasada!");
            }
        }
    }
}

void ValidacaoDescarte()
{
    // identifica tamanho da garrafa
    if (ValidaGarrafa())
    {
        if (!esteira1Ligada)
        {
            ComandaEsteira(1, 1);
        }

        if (!esteira2Ligada)
        {
            if (emEnvase)
            {
                delay(3000); // ajustar delay p/ envase
                ComandaEsteira(2, 1);
            }
            else
            {
                ComandaEsteira(2, 1);
            }
        }
    }
    else
    {
        // descarte da garrafa
        digitalWrite(atuadorC, HIGH);
        if (digitalRead(sensorA) == 0)
        {
            Serial.println("Garrafa descartada!");
        }
    }
}

void RecebeComandos()
{
    stringComplete = false;
    getCommand();

    if (commandString.equals("GARRAFA200ML"))
    {
        bool stateGarrafa = getStateGarrafa();
        if (stateGarrafa == true)
        {
            tamanhoGarrafa = 1;
        }
        else
        {
            tamanhoGarrafa = 0;
        }
    }
    else if (commandString.equals("GARRAFA300ML"))
    {
        bool stateGarrafa = getStateGarrafa();
        if (stateGarrafa == true)
        {
            tamanhoGarrafa = 2;
        }
        else
        {
            tamanhoGarrafa = 0;
        }
    }
    else if (commandString.indexOf("ESTEIRA") != -1)
    {
        SetaVelocidadeEsteiras();
    }

    inputString = "";
}

bool ValidaGarrafa()
{
    if (tamanhoGarrafa == 1)
    {
        if (digitalRead(sensorB) == 0)
        {
            return true;
        }
    }
    else
    {
        if (digitalRead(sensorB) != 0)
        {
            return true;
        }
    }
}

void SetaVelocidadeEsteiras()
{
    if (commandString.indexOf("ESTEIRA1") != -1)
    {
        if (commandString.indexOf("V1") >= 0)
        {
            vel1 = 50;
            ComandaEsteira(1, 1);
        }
        else if (commandString.indexOf("V2") >= 0)
        {
            vel1 = 60;
            ComandaEsteira(1, 1);
        }
        else if (commandString.indexOf("V3") >= 0)
        {
            vel1 = 90;
            ComandaEsteira(1, 1);
        }
        else
        {
            vel1 = 0;
            ComandaEsteira(1, 0);
        }
    }
    else if (commandString.indexOf("ESTEIRA2") != 1)
    {
        if (commandString.indexOf("V1") != -1)
        {
            vel2 = 70;
            ComandaEsteira(2, 1);
        }
        else if (commandString.indexOf("V2") != -1)
        {
            vel2 = 150;
            ComandaEsteira(2, 1);
        }
        else if (commandString.indexOf("V3") != -1)
        {
            vel2 = 255;
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
    emEnvase = true;
    // garrafa 200mL
    if (tamanhoGarrafa == 1)
    {
        digitalWrite(solenoide, HIGH);
        long int t1 = millis();
        delay(3000); // ajustar tempo do delay aqui
        long int t2 = millis();

        if (digitalRead(sensorE) != 0 || t2 - t1 > 3000) // e aqui
        {
            // Tem o tamanho pequeno e chegou ao fim do envase
            digitalWrite(solenoide, LOW);
            delay(1000);

            digitalWrite(atuadorB, LOW);
            delay(1000);
            digitalWrite(atuadorA, LOW);

            if (!esteira2Ligada)
            {
                ComandaEsteira(2, 1);
            }
        }
    }
    else
    {
        digitalWrite(solenoide, HIGH);
        long int t1 = millis();
        delay(3000);
        long int t2 = millis();

        if (digitalRead(sensorE) != 0 || t2 - t1 > 3000)
        {
            // Tem o tamanho grande e chegou ao fim do envase
            digitalWrite(solenoide, LOW);
            delay(1000);

            digitalWrite(atuadorB, LOW);
            delay(1000);
            digitalWrite(atuadorA, LOW);

            if (!esteira2Ligada)
            {
                ComandaEsteira(2, 1);
            }
        }
    }
    emEnvase = false;
}

bool ChecagemTanque()
{
    if (digitalRead(sensorF) == 0)
    {
        return true;
    }
}

void ComandaBomba()
{
    digitalWrite(bomba, HIGH);

    if (digitalRead(sensorG) != 0)
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
            commandString = inputString.substring(1, 13);
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
            analogWrite(velmotor1, vel1);

            digitalWrite(mla1, LOW);
            digitalWrite(mlb1, HIGH);
            esteira1Ligada = true;
        }
        else
        {
            digitalWrite(mla1, LOW);
            digitalWrite(mlb1, LOW);
            esteira1Ligada = false;
        }
    }
    else
    {
        if (comando == 1)
        {
            analogWrite(velmotor2, vel2);

            digitalWrite(mla2, HIGH);
            digitalWrite(mlb2, LOW);
            esteira2Ligada = true;
        }
        else
        {
            digitalWrite(mla2, LOW);
            digitalWrite(mlb2, LOW);
            esteira2Ligada = false;
        }
    }
}

bool getStateGarrafa()
{
    bool state = false;
    
    if (inputString.substring(13, 15).equals("ON"))
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