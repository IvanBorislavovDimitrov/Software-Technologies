package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {

    public Film() {}

    public Film(String name, String genre, String director, Integer year) {
        this.name = name;
        this.genre = genre;
        this.director = director;
        this.year = year;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

    @Column(columnDefinition = "text", nullable = false)
    private String name;

    @Column(columnDefinition = "text", nullable = false)
    private String genre;

    @Column(columnDefinition = "text", nullable = false)
    private String director;

    @Column(nullable = false)
    private Integer year;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public String getDirector() {
        return director;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    public Integer getYear() {
        return year;
    }

    public void setYear(Integer year) {
        this.year = year;
    }
}
