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


// leituras analógicas
#define sensorA A0 // infra-vermelho
#define sensorB A1 // infra-vermelho
#define sensorC A2 // infra-vermelho
#define sensorD A3 // infra-vermelho

int tamanhoGarrafa = 1; //pequena

void setup()
{
    Serial.begin(9600);
    pinMode(rele, OUTPUT);

    // atuadorA inicia avançado
    digitalWrite(esteira2, LOW);
    digitalWrite(atuadorA, HIGH);
    digitalWrite(atuadorB, HIGH);
    servo.attach(2);
}

void loop()
{
    if(ChecagemTanque())
    {
        ComandaBomba();
    }

    if (analogRead(sensorA) != 0)
    {
        // liga esteira
        digitalWrite(esteira1, HIGH);
        Serial.println("Esteira em funcionamento!");
        delay(1000);

        // identifica garrafa na estação de validação
        if (analogRead(sensorB) != 0)
        {
            digitalWrite(atuadorA, HIGH);
            digitalWrite(esteira1, LOW);

            // identifica tamanho da garrafa
            if (ValidaGarrafa())
            {
                digitalWrite(atuadorA, LOW);
                digitalWrite(esteira1, HIGH);
                digitalWrite(esteira2, HIGH);

                // identifica chegada da garrafa na estação de envase
                if (analogRead(sensorD) != 0)
                {
                    digitalWrite(esteira1, LOW);
                    digitalWrite(esteira2, LOW);

                    delay(5000);

                    // inicio do envase
                    ExecutaEnvase();
                }
            }
            else
            {
                // descarte da garrafa
                digitalWrite(atuadorC, HIGH);
                if (analogRead(sensorB) == 0)
                {
                    Serial.println("Garrafa descartada!");
                }
            }
        }
    }
}

bool ValidaGarrafa() 
{
    if(tamanhoGarrafa == 1)
    {
        if(analogRead(sensorC) == 0)
            return true;
    }
    else
    {
        if(analogRead(sensorC) != 0)
            return true;
    }
}

void ExecutaEnvase()
{
    //garrafa pequena
    if(tamanhoGarrafa == 1)
    {
        myservo.write(180);
        delay(500);

        digitalWrite(solenoide, HIGH);

        if (digitalRead(sensorE) == HIGH && digitalRead(sensorF) == LOW)
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
        myservo.write(0);
        delay(500);

        digitalWrite(solenoide, HIGH);

        if (digitalRead(sensorF) == HIGH)
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
    if(digitalRead(sensorG) == LOW) 
    {
        return true;
    }

}

void ComandaBomba()
{
    digitalWrite(bomba, HIGH);

    if(digitalRead(sensorH) == HIGH)
    {
        digitalWrite(bomba, LOW);
    }
}