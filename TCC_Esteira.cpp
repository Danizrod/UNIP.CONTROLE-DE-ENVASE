// leituras digitais
#define bomba 22
#define atuadorA 25 // parada1
#define atuadorB 24 // parada2
#define atuadorC 23 // rejeição
#define solenoide 26

// esteira1 validação
#define velmotor1 7
#define mla1 6
#define mlb1 5

// esteira2 envase
#define velmotor2 4
#define mla2 2
#define mlb2 3

// sensores
#define sensorA 52 // infra-vermelho
#define sensorB 50 // infra-vermelho
#define sensorC 48 // infra-vermelho
#define sensorD 46 // infra-vermelho

#define sensorE 44 // capacitivo
#define sensorF 42 // capacitivo
#define sensorG 40 // capacitivo

// Variaveis
int vel1 = 0;
bool esteira1Ligada = false;
int vel2 = 0;
bool esteira2Ligada = false;
bool emEnvase = false;
int tamanhoGarrafa = 0;    // 0 é nenhuma, 1 é 200mL e 2 é 300mL
String inputString = "";   // string bruta passada pelo programa
String commandString = ""; // string refinada p/ comando
boolean stringComplete = false;
boolean emVerificacao = false;
int garrafasEnvasadas200 = 0;
int garrafasEnvasadas300 = 0;
int garrafasDescartadas200 = 0;
int garrafasDescartadas300 = 0;
int tempo = 0;

void setup()
{
    Serial.begin(9600);

    pinMode(atuadorA, OUTPUT);
    pinMode(atuadorB, OUTPUT);
    pinMode(atuadorC, OUTPUT);
    pinMode(bomba, OUTPUT);
    pinMode(solenoide, OUTPUT);

    digitalWrite(atuadorA, HIGH);
    digitalWrite(atuadorB, LOW);
    digitalWrite(atuadorC, HIGH);
    digitalWrite(solenoide, HIGH);
    digitalWrite(bomba, HIGH);

    pinMode(sensorA, INPUT); // infra-vermelho
    pinMode(sensorB, INPUT); // infra-vermelho
    pinMode(sensorC, INPUT); // infra-vermelho
    pinMode(sensorD, INPUT); // infra-vermelho

    pinMode(sensorE, OUTPUT); // capacitivo
    pinMode(sensorF, OUTPUT); // capacitivo
    pinMode(sensorG, OUTPUT); // capacitivo

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
        // identifica garrafa na estação de validação
        if (digitalRead(sensorA) != 1)
        {
            if (esteira1Ligada)
            {
                ComandaEsteira(1, 0);
            }

            delay(2000);

            if (!emVerificacao)
            {
                ValidacaoDescarte();
            }

            delay(500);
        }

        // identifica chegada da garrafa na estação de envase
        if (digitalRead(sensorC) != 1)
        {
            delay(100);
            if (esteira2Ligada)
            {
                ComandaEsteira(2, 0);
            }

            if (!emEnvase)
            {
                ExecutaEnvase();
            }
        }
    }
}

void ValidacaoDescarte()
{
    emVerificacao = true;
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
        digitalWrite(atuadorC, LOW);
        if (tamanhoGarrafa == 1)
        {
            garrafasDescartadas200 += 1;
        }
        else
        {
            garrafasDescartadas300 += 1;
        }

        delay(500);
        digitalWrite(atuadorC, HIGH);
        delay(500);

        if (!esteira1Ligada)
        {
            ComandaEsteira(1, 1);
        }
    }
    emVerificacao = false;
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

            if (!esteira1Ligada)
            {
                ComandaEsteira(1, 1);
            }
        }
        else
        {
            tamanhoGarrafa = 0;
            if (esteira1Ligada)
            {
                ComandaEsteira(1, 0);
            }

            if (esteira2Ligada)
            {
                ComandaEsteira(2, 0);
            }
        }
    }
    else if (commandString.equals("GARRAFA300ML"))
    {
        bool stateGarrafa = getStateGarrafa();
        if (stateGarrafa == true)
        {
            tamanhoGarrafa = 2;

            if (!esteira1Ligada)
            {
                ComandaEsteira(1, 1);
            }
        }
        else
        {
            tamanhoGarrafa = 0;
            if (esteira1Ligada)
            {
                ComandaEsteira(1, 0);
            }

            if (esteira2Ligada)
            {
                ComandaEsteira(2, 0);
            }
        }
    }
    else if (commandString.indexOf("ESTEIRA") != -1)
    {
        SetaVelocidadeEsteiras();
    }
    else if (commandString.indexOf("PARARENVASE") != -1)
    {
        digitalWrite(solenoide, LOW);
    }
    else if (commandString.indexOf("PARARPROCESSO") != -1)
    {
        ParaProcesso();
    }
    else if (commandString.indexOf("CHECARDADOS") != -1)
    {
        String str = "GE2:" + String(garrafasEnvasadas200) + ".GE3:" + String(garrafasEnvasadas300) + ".GD2:" + String(garrafasDescartadas200) + ".GD3:" + String(garrafasDescartadas300);

        // NÃO REMOVER ESTE PRINT EM HIPÓTESE ALGUMA
        Serial.println(str);
    }
    else if (commandString.indexOf("RESETA") != -1)
    {
        garrafasEnvasadas200 = 0;
        garrafasEnvasadas300 = 0;
        garrafasDescartadas200 = 0;
        garrafasDescartadas300 = 0;
    }

    inputString = "";
}

void ParaProcesso()
{
    ComandaEsteira(1, 0);
    ComandaEsteira(2, 0);

    tamanhoGarrafa = 0;
    garrafasEnvasadas200 = 0;
    garrafasEnvasadas300 = 0;
    garrafasDescartadas200 = 0;
    garrafasDescartadas300 = 0;

    digitalWrite(atuadorA, HIGH);
    digitalWrite(atuadorB, LOW);
    digitalWrite(atuadorC, HIGH);
    digitalWrite(solenoide, HIGH);

    vel1 = 0;
    esteira1Ligada = false;
    vel2 = 0;
    esteira2Ligada = false;
    emEnvase = false;
    emVerificacao = false;
}

bool ValidaGarrafa()
{
    if (tamanhoGarrafa == 1)
    {
        if (digitalRead(sensorB) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        if (digitalRead(sensorB) != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

void SetaVelocidadeEsteiras()
{
    if (commandString.indexOf("ESTEIRA1") != -1)
    {
        if (commandString.indexOf("V1") >= 0)
        {
            vel1 = 55;
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
            vel2 = 190;
            ComandaEsteira(2, 1);
        }
        else if (commandString.indexOf("V2") != -1)
        {
            vel2 = 220;
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
    emEnvase = 1;
    digitalWrite(atuadorA, LOW);
    delay(1000);
    digitalWrite(solenoide, LOW);
    long int t1 = millis();
    if (tamanhoGarrafa == 1)
    {
        tempo = 4002;
    }
    else
    {
        tempo = 6202;
    }
    delay(tempo); // ajustar tempo do delay aqui
    long int t2 = millis();
    if (t2 - t1 > (tempo - 2) || digitalRead(sensorE) != 0) // e aqui
    {
        // Tem o tamanho pequeno e chegou ao fim do envase
        digitalWrite(solenoide, HIGH);
        delay(1000);
        digitalWrite(atuadorB, HIGH);
        delay(1000);
        emEnvase = 0;
        if (!esteira2Ligada)
        {
            ComandaEsteira(2, 1);
        }
        digitalWrite(atuadorA, HIGH);
        delay(2000);
        digitalWrite(atuadorB, LOW);

        if (tamanhoGarrafa == 1)
        {
            garrafasEnvasadas200 += 1;
        }
        else
        {
            garrafasEnvasadas300 += 1;
        }
    }
}

bool ChecagemTanque()
{
    if (digitalRead(sensorG) == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

void ComandaBomba()
{
    // digitalWrite(bomba, LOW);

    if (digitalRead(sensorF) != 0)
    {
        digitalWrite(bomba, HIGH);
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
        else if (inputString.indexOf("PARARENVASE") != -1)
        {
            commandString = inputString.substring(1, 12);
        }
        else if (inputString.indexOf("PARARPROCESSO") != -1)
        {
            commandString = inputString.substring(1, 14);
        }
        else if (inputString.indexOf("CHECARDADOS") != -1)
        {
            commandString = inputString.substring(1, 12);
        }
        else if (inputString.indexOf("RESETAR") != -1)
        {
            commandString = inputString.substring(1, 7);
        }
    }
}

void ComandaEsteira(int esteira, bool comando)
{
    if (esteira == 1)
    {
        if (comando == 1)
        {
            if(vel1 == 0) 
            {
                vel1 = 55;
            }
            analogWrite(velmotor1, vel1);

            digitalWrite(mla1, LOW);
            digitalWrite(mlb1, HIGH);
            esteira1Ligada = true;
        }
        else
        {
            vel1 = 0;
            analogWrite(velmotor1, vel1);

            digitalWrite(mla1, LOW);
            digitalWrite(mlb1, LOW);
            esteira1Ligada = false;
        }
    }
    else
    {
        if (comando == 1)
        {
            if(vel2 == 0) 
            {
                vel2 = 220;
            }
            analogWrite(velmotor2, vel2);

            digitalWrite(mla2, HIGH);
            digitalWrite(mlb2, LOW);
            esteira2Ligada = true;
        }
        else
        {
            vel2 = 0;
            analogWrite(velmotor2, vel2);

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