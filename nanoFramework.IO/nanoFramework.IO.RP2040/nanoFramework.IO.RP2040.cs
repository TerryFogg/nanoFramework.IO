using System;

namespace nanoFramework.IO.RP2040
{
    //  RP2040 has 36 multi-functional General Purpose Input / Output(GPIO) pins, divided into two banks.
    //  (QSPI_SS, QSPI_SCLK and QSPI_SD0 to QSPI_SD3) are used to execute code from an external flash device.
    //  This leaves the User bank(GPIO0 to GPIO29) for the general use.
    //  All GPIOs support digital input and output
    //  GPIO26 to GPIO29 can also be used as Analogue to Digital Converter (ADC).
    //  Each GPIO can have one function selected at a time.
    //  Each peripheral input (e.g.UART0 RX) should only be selected on one _GPIO_ at a time.
    //  If the same peripheral input is connected to multiple GPIOs, the peripheral sees the logical OR of these
    //  GPIO inputs.
    //  
    public static class RP2040
    {
        /// <summary>
        /// GPIO numbers and their associated physical pin numbers on the RP2040 SOC
        /// </summary>
        public enum Gpio
        {
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 RX  | UART0 TX  | I2C0 SDA | PWM0 A
            /// </summary>
            Gpio0 = 2,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 CSn | UART0 RX  | I2C0 SCL | PWM0 B
            /// </summary>
            Gpio1 = 3,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 SCK | UART0 CTS | I2C1 SDA | PWM1 A
            /// </summary>
            Gpio2 = 4,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate  SPI0 TX  | UART0 RTS | I2C1 SCL | PWM1 B
            /// </summary>
            Gpio3 = 5,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate  SPI0 RX  | UART1 TX  | I2C0 SDA | PWM2 A
            /// </summary>
            Gpio4 = 6,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate  SPI0 CSn | UART1 RX  | I2C0 SCL | PWM2 B
            /// </summary>
            Gpio5 = 7,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 SCK | UART1 CTS | I2C1 SDA | PWM3 A
            /// </summary>
            Gpio6 = 8,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 TX  | UART1 RTS | I2C1 SCL | PWM3 B
            /// </summary>
            Gpio7 = 9,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 RX  | UART1 TX  | I2C0 SDA | PWM4 A
            /// </summary>
            Gpio8 = 11,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate  SPI1 CSn | UART1 RX  | I2C0 SCL | PWM4 B
            /// </summary>
            Gpio9 = 12,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 SCK | UART1 CTS | I2C1 SDA | PWM5 A
            /// </summary>
            Gpio10 = 13,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 TX  | UART1 RTS | I2C1 SCL | PWM5 B
            /// </summary>
            Gpio11 = 14,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 RX  | UART0 TX  | I2C0 SDA | PWM6 A
            /// </summary>
            Gpio12 = 15,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 CSn | UART0 RX  | I2C0 SCL | PWM6 B
            /// </summary>
            Gpio13 = 16,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 SCK | UART0 CTS | I2C1 SDA | PWM7 A
            /// </summary>
            Gpio14 = 17,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 TX  | UART0 RTS | I2C1 SCL | PWM7 B
            /// </summary>
            Gpio15 = 18,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 RX  | UART0 TX  | I2C0 SDA | PWM0 A
            /// </summary>
            Gpio16 = 27,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 CSn | UART0 RX  | I2C0 SCL | PWM0 B
            /// </summary>
            Gpio17 = 28,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 SCK | UART0 CTS | I2C1 SDA | PWM1 A
            /// </summary>
            Gpio18 = 29,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 TX  | UART0 RTS | I2C1 SCL | PWM1 B
            /// </summary>
            Gpio19 = 30,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 RX  | UART1 TX  | I2C0 SDA | PWM2 A
            /// </summary>
            Gpio20 = 31,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 CSn | UART1 RX  | I2C0 SCL | PWM2 B
            /// </summary>
            Gpio21 = 32,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 SCK | UART1 CTS | I2C1 SDA | PWM3 A
            /// </summary>
            Gpio22 = 34,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI0 TX  | UART1 RTS | I2C1 SCL | PWM3 B
            /// </summary>
            Gpio23 = 35,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 RX  | UART1 TX  | I2C0 SDA | PWM4 A
            /// </summary>
            Gpio24 = 36,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 CSn | UART1 RX  | I2C0 SCL | PWM4 B
            /// </summary>
            Gpio25 = 37,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate  SPI1 SCK | UART1 CTS | I2C1 SDA | PWM5 A
            /// </summary>
            ADC0_Gpio26 = 38,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 TX  | UART1 RTS | I2C1 SCL | PWM5 B
            /// </summary>
            ADC1_Gpio27 = 39,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 RX  | UART0 TX  | I2C0 SDA | PWM6 A
            /// </summary>
            ADC2_Gpio28 = 40,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate SPI1 CSn | UART0 RX  | I2C0 SCL | PWM6 B
            /// </summary>
            ADC3_Gpio29 = 41,
            /// <summary>
            /// Digital IO (Fault Tolerant - Reset state -> Pull Down, 4ma Drive)
            /// Alternate 
            /// </summary>

        }

        


    }


    public class temp
    {

        /// <summary>
        /// PinType
        /// GPIO capabilities, documentation taken from RP2040 datasheet, build-date: 2022-06-17
        /// </summary>
        internal enum PinType
        {
            /// <summary>
            /// Input Only/Standard Digital
            /// Programmable Pull-Up, Pull-Down, Slew Rate
            /// Schmitt Trigger and Drive Strength
            /// Default Drive Strength is 4mA
            /// </summary>
            DigitalIn,

            /// <summary>
            /// Bi-directional/Standard Digital
            /// Programmable Pull-Up, Pull-Down, Slew Rate
            /// Schmitt Trigger and Drive Strength
            /// Default Drive Strength is 4mA
            /// </summary>
            DigitalBidirectional,

            /// <summary>
            /// Input Only/Fault Tolerant Digital. 
            /// These pins are described as Fault Tolerant
            /// which in this case means that very little current flows into the pin
            /// whilst it is below 3.63V and IOVDD is 0V.
            /// There is also enhanced ESD protection on these pins.
            /// Programmable Pull-Up, Pull-Down, Slew Rate
            /// Schmitt Trigger and Drive Strength.
            /// Default Drive Strength is 4mA.
            /// </summary>
            DigitalInput_FaultTolerant,

            /// <summary>
            /// Bi-directional/Fault Tolerant Digital. 
            /// These pins are described as Fault Tolerant
            /// which in this case means that very little current flows into the pin
            /// whilst it is below 3.63V and IOVDD is 0V.
            /// There is also enhanced ESD protection on these pins.
            /// Programmable Pull-Up, Pull-Down, Slew Rate
            /// Schmitt Trigger and Drive Strength.
            /// Default Drive Strength is 4mA.
            /// </summary>
            DigitalBidirectional_FaultTolerant,

            /// <summary>
            ///  Bi-directional/Standard Digital and ADC input. 
            ///  Programmable Pull-Up, Pull-Down,
            ///  Slew Rate, Schmitt Trigger and Drive Strength. Default 
            ///  Drive Strength is 4mA.
            /// </summary>
            DigitalBidirectional_Analogue,

            /// <summary>
            //   These pins are for USB use, and contain internal pull-up and pull-down
            //   resistors, as per the USB specification. Note that external 27Ω series
            //   resistors are required for USB operation
            /// </summary>
            UsbBidirectional,
        }

        internal enum GpioFeatures
        {
            /// <summary>
            ///  Output disable. Has priority over output enable from
            /// </summary>
            OutputDriverDisabled = 0,
            OutputDriverEnabled = 1,
            OutputDriverDefault = OutputDriverDisabled,

            /// <summary>
            /// The input buffer can be disabled, 
            /// to reduce current consumption when the pad is unused,
            /// unconnected or connected to an analogue signal.
            /// peripherals
            /// </summary>
            InputBufferDisabled = 0,
            InputBufferEnabled = 1,
            InputBufferDefault = InputBufferDisabled,

            /// <summary>
            // A pull-up or pull-down can be enabled,
            // to set the output signal level when the output driver is disabled
            /// </summary>
            PullUpDisabled = 0,
            PullUpEnabled = 1,
            PullUpDefault = PullDownDisabled,
            PullDownDisabled = 0,
            PullDownEnabled = 1,
            PullDownDefault = PullDownDisabled,

            /// <summary>
            /// The GPIOs on RP2040 have four different output drive strengths,
            /// which are nominally called 2, 4, 8 and 12mA modes.
            /// These are not hard limits, nor do they mean that they will always be sourcing (or sinking)
            /// the selected amount of milliamps. The amount of current a GPIO sources or sinks
            /// is dependant on the load attached to it.
            /// </summary>
            Strength2ma = 0,
            Strength4ma = 1,
            Strength8ma = 2,
            Strength12ma = 3,
            StrengthDefault = Strength4ma,

            /// <summary>
            /// Input hysteresis (schmitt trigger mode)
            /// </summary>
            SchmittEnable = 1,
            SchmittDisable = 2,
            ScmittDefault = SchmittEnable,

            /// <summary>
            /// How fast to drive the Pin 
            /// Slew Rate
            /// 
            /// </summary>
            SlewSlow = 0,
            SlewFast = 1,
            SlewDefault = SlewSlow,
        }

        /// <summary>
        ///  Using IOVDD voltages greater than 1.8V, with the input thresholds set for 1.8V may result in damage to the chip
        /// </summary>
        internal enum GpioVoltageSelect
        {
            Voltage3_3V = 0,
            Voltage1_8V = 1,
            Default = Voltage3_3V
        }

        enum Functions
        {
            I2C0,
            I2C1,
            SPI0,
            SPI1,
            UART0,
            UART1,
            PWM0A,
            PWM0B,
            PWM1A,
            PWM1B,
            PWM2A,
            PWM2B,
            PWM3A,
            PWM3B,
            PWM4A,
            PWM4B,
            PWM5A,
            PWM5B,
            PWM6A,
            PWM6B,
            PWM7A,
            PWM7B,
            CLOCK_GPIN0,
            CLOCK_GPOUT0,
            CLOCK_GPIN1,
            CLOCK_GPOUT1,
            CLOCK_GPOUT2,
            CLOCK_GPOUT3
        }

        /// <summary>
        ///  The I2C block must only be programmed to operate in either master OR slave mode only.
        ///  Operating as a master and slave simultaneously is not supported
        ///  The I2C block can operate in these modes
        ///  - standard mode (with data rates from 0 to 100kbps)
        ///  - fast mode (with data rates less than or equal to 400kbps)
        ///  - fast mode plus(with data rates less than or equal to 1000kbps).
        /// </summary>
        enum I2C
        {
            StandardMode = 100,
            FastMode = 400,
            FastModePlus = 1000
        }




    }


}
