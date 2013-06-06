var vehiclesNS = (function () {
    var LAND_VEHICLE_WHEELS_COUNT = 4;

    var AfterburnerState = {
        "OFF": "OFF",
        "ON": "ON"
    };

    var SpinDirection = {
        "CLOCKWISE": "CLOCKWISE",
        "COUNTERCLOCKWISE": "COUNTERCLOCKWISE"
    };

    var AmphibiaMode = {
        "LAND": "LAND",
        "WATER": "WATER"
    };

    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    }

    Function.prototype.extend = function (parent) {
        for (var i = 1; i < arguments.length; i += 1) {
            var property = arguments[i];
            this.prototype[property] = parent.prototype[property];
        }

        return this;
    }

    // Propulsion unit class and methods
    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
        throw new Error("Cannot get acceleration without specifying the propulsion unit type!");
    }

    // Wheel class and methods
    function Wheel(radiusInInches) {
        if (radiusInInches <= 0) {
            throw new RangeError("Wheel's radius must be a positive number!");
        }

        this.radius = radiusInInches;
    }

    Wheel.inherit(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        var acceleration = 2 * Math.PI * this.radius;
        return acceleration;
    }

    // Propelling nozzle class and methods
    function PropellingNozzle(powerInHp, afterburnerState) {
        if (powerInHp <= 0) {
            throw new RangeError("Propelling nozzle's power must be a positive number!");
        }

        if (afterburnerState != AfterburnerState.OFF && afterburnerState != AfterburnerState.ON) {
            throw new Error("Provided afterburner state is invalid!");
        }

        this.power = powerInHp;
        this.afterburnerState = afterburnerState;
    }

    PropellingNozzle.inherit(PropulsionUnit);

    PropellingNozzle.prototype.getAcceleration = function () {
        var acceleration;
        if (this.afterburnerState == AfterburnerState.OFF) {
            acceleration = this.power;
        } else {
            acceleration = 2 * this.power;
        }

        return acceleration;
    }
    
    // Propeller class and methods
    function Propeller(finsCount, spinDirection) {
        if (finsCount <= 0) {
            throw new RangeError("Propeller's fins count must be a positive number!");
        }

        if (spinDirection != SpinDirection.CLOCKWISE && spinDirection != SpinDirection.COUNTERCLOCKWISE) {
            throw new Error("Provided spin direction is invalid!");
        }

        this.finsCount = finsCount;
        this.spinDirection = spinDirection;
    }

    Propeller.inherit(PropulsionUnit);

    Propeller.prototype.getAcceleration = function () {
        var acceleration;
        if (this.spinDirection == SpinDirection.CLOCKWISE) {
            acceleration = this.finsCount;
        } else {
            acceleration = -1 * this.finsCount;
        }

        return acceleration;
    }

    // Vehicle class and methods
    function Vehicle(speedInKmH, propulsionUnits) {
        this.speed = speedInKmH;
        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function () {
        var propulsionUnitsCount = this.propulsionUnits.length;
        for (var i = 0; i < propulsionUnitsCount; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    // Land vehicle class and methods
    function LandVehicle(speedInKmH, wheels) {
        if (wheels.length != LAND_VEHICLE_WHEELS_COUNT) {
            throw new Error("Invalid number of wheels for land vehicle!");
        }

        Vehicle.call(this, speedInKmH, wheels);
    }

    LandVehicle.inherit(Vehicle);

    // Air vehicle class and methods
    function AirVehicle(speedInKmH, propellingNozzle) {
        Vehicle.call(this, speedInKmH, [propellingNozzle]);
    }

    AirVehicle.inherit(Vehicle);

    AirVehicle.prototype.setAfterburnerState = function (afterBurnerState) {
        var propulsionUnitsCount = this.propulsionUnits.length;
        for (var i = 0; i < propulsionUnitsCount; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                this.propulsionUnits[i].afterburnerState = afterBurnerState;
            }
        }
    }

    // Water vehicle class and methods
    function WaterVehicle(speedInKmH, propellers) {
        Vehicle.call(this, speedInKmH, propellers);
    }

    WaterVehicle.inherit(Vehicle);

    WaterVehicle.prototype.setPropellersSpinDirection = function (spinDirection) {
        var propulsionUnitsCount = this.propulsionUnits.length;
        for (var i = 0; i < propulsionUnitsCount; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].spinDirection = spinDirection;
            }
        }
    }

    // Amphibious vehicle class and methods
    function Amphibia(speedInKmH, propeller, wheels, mode) {
        var propulsionUnits = [];
        propulsionUnits.push(propeller);
        
        for (var i = 0, wheelsCount = wheels.length; i < wheelsCount; i++) {
            propulsionUnits.push(wheels[i]);
        }

        Vehicle.call(this, speedInKmH, propulsionUnits);
        this.mode = mode;
    }

    Amphibia.inherit(Vehicle);
    Amphibia.extend(WaterVehicle, "setPropellersSpinDirection");

    Amphibia.prototype.setMode = function (mode) {
        this.mode = mode;
    }

    Amphibia.prototype.accelerate = function () {
        if (this.mode == AmphibiaMode.LAND) {
            var propulsionUnitsCount = this.propulsionUnits.length;
            for (var i = 1; i < propulsionUnitsCount; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else {
            this.speed += this.propulsionUnits[0].getAcceleration();
        }
    }

    // Public classes for the outher world
    return {
        Amphibia: Amphibia,
        AirVehicle: AirVehicle,
        LandVehicle: LandVehicle,
        WaterVehicle: WaterVehicle,
        AfterburnerState: AfterburnerState,
        SpinDirection: SpinDirection,
        AmphibiaMode: AmphibiaMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller
    }
})();