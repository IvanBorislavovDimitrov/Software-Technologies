package blog.blog.service;

import blog.blog.config.BlogUserDetails;
import blog.blog.entity.User;
import blog.blog.repository.UserRepository;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.Set;
import java.util.stream.Collectors;

@Service("blogUserDetailsService")
public class BlogUserDetailsService implements UserDetailsService {
    private final UserRepository userRepository;

    public BlogUserDetailsService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException {
        User user = this.userRepository.findByEmail(email);

        if (user == null) {
            throw new UsernameNotFoundException("Invalid user!");
        }

        Set<GrantedAuthority> grantedAuthorities = user.getRoles()
                .stream()
                .map(x -> new SimpleGrantedAuthority(x.getName()))
                .collect(Collectors.toSet());

        return new org.springframework.security.core.userdetails
                .User(user.getEmail(), user.getPassword(), grantedAuthorities);
    }
}
