<?php

namespace CalculatorBundle\Entity;

class Calculator {
    /**
     * @var float
     */
    private $leftOperand;

    /**
     * @var float
     */
    private $rightOperand;

    /**
     * @var string
     */
    private $operator;

    /**
     * @return float
     */
    public function getLeftOperand() {
        return $this->leftOperand;
    }

    /**
     * @return float
     */
    public function getRightOperand() {
        return $this->rightOperand;
    }

    /**
     * @return string
     */
    public function getOperator() {
        return $this->operator;
    }

    /**
     * @param float $operand
     *
     * @return Calculator
     */
    public function setLeftOperand($operand) {
        $this->leftOperand = $operand;

        return $this;
    }

    /**
     * @param float $operand
     *
     * @return Calculator
     */
    public function setRightOperand($operand) {
        $this->rightOperand = $operand;

        return $this;
    }

    /**
     * @param string $operator
     *
     * @return Calculator
     */
    public function setOperator($operator) {
        $this->operator = $operator;

        return $this;
    }
}