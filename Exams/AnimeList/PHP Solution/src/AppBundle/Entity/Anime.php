<?php

namespace AppBundle\Entity;

use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Validator\Constraints\NotBlank;

/**
 * Anime
 *
 * @ORM\Table(name="animes")
 * @ORM\Entity(repositoryClass="AppBundle\Repository\AnimeRepository")
 */
class Anime
{
    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @var integer
     *
     * @ORM\Column(type="string", length=255)
     * @NotBlank
     */
    private $rating;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string")
     * @NotBlank
     */
    private $name;

    /**
     * @var string
     *
     * @ORM\Column(name="description", type="string")
     * @NotBlank
     */
    private $description;

    /**
     * @var string
     *
     * @ORM\Column(name="watched", type="string")
     * @NotBlank
     */
    private $watched;

    /**
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @param int $id
     */
    public function setId(int $id)
    {
        $this->id = $id;
    }

    /**
     * @return int
     */
    public function getRating()
    {
        return $this->rating;
    }

    /**
     * @param int $rating
     */
    public function setRating(int $rating)
    {
        $this->rating = $rating;
    }

    /**
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @param string $name
     */
    public function setName(string $name)
    {
        $this->name = $name;
    }

    /**
     * @return string
     */
    public function getDescription()
    {
        return $this->description;
    }

    /**
     * @param string $description
     */
    public function setDescription(string $description)
    {
        $this->description = $description;
    }

    /**
     * @return string
     */
    public function getWatched()
    {
        return $this->watched;
    }

    public function setWatched($watched) {
        $this->watched = $watched;
    }
}

